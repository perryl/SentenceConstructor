using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Tests
{
    [TestClass()]
    public class FragmentConstructorTests
    {
        [TestMethod()]
        public void OverlapTest()
        {
            string strA = "abcd ef";
            string strB = "cd efgh";
            string expected = "cd ef";
            string actual = ConsoleApplication.FragmentConstructor.Overlap("abcd ef", "cd efgh");
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CheckOverlapListTest()
        {
            string strA = "ab efghcd ef";
            string strB = "cd efgh";
            String[] array = { "cd", "cd ", "cd e", "cd ef", " e", " ef", " efg", " efgh"};
            string expected = "cd ef";
            string actual = ConsoleApplication.FragmentConstructor.CheckOverlapList(list, strA, strB);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void MergeTest()
        {
            String[] array = { "abc", "bcd", "def" };
            String[] expected = { "abcd", "def" };
            String[] actual = ConsoleApplication.FragmentConstructor.Merge(
                array[0], array[1], "bc", array);
            Assert.AreEqual(actual, expected);
        }
    }
}