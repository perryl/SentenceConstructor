using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class FragmentConstructor
    {
        public static String[] fragments = new String[] {
            "it amet consectetur", "sit a", "r adipiscing elit", "Lorem ipsu", "psum dolor sit amet"
        }; // Five fragments comprising the first line of Lorem Ipsum

        public static void Main(string[] fragments)
        {
            var overlapCheck = new List<Tuple<string, string, string, int>>();
            String[] checkedFragments = CheckFragments(fragments);
            int length = checkedFragments.Length;

            while (length > 1) {
                for (int i = 0; i < length; i++) {
                    for (int j = i + 1; j < length; j++) {

                        string overlap = Overlap(checkedFragments[i], checkedFragments[j]);
                        overlapCheck.Add(Tuple.Create(checkedFragments[i], checkedFragments[j], overlap, overlap.Length));
                        Console.WriteLine("Comparing \"{0}\" and \"{1}\"...Overlap: \"{2}\", length: {3}",
                            checkedFragments[i], checkedFragments[j], overlap, overlap.Length);
                    }
                    // Now sort overlapCheck by descending size of overlap.Length (Tuple.Item4)
                }
            }
        }

        public static String[] CheckFragments(String[] fragments)
        {
            // Perform sanity checking on sentence fragments (i.e. size < 1000 characters, characters valid)
            int maxStringLength = 1000;
            int length = fragments.Length;
            List<string> list = new List<string>();

            for (int i = 0; i < length; i++) {
                if (fragments[i].Length < maxStringLength && fragments[i].Length > 0) {
                    list.Add(fragments[i]);
                }
            }
            string[] checkedFragments = list.ToArray();
            return checkedFragments;
        }

        public static String Overlap(string stringA, string stringB)
        {
            // Take two strings as argument, check if overlap between the two, return substring of overlapped chars

            int[,] match = new int[stringA.Length, stringB.Length];
            int overlapSize = 0, overlapIndex = 0;
            List<char> overlapChar = new List<char>();

            for (int i = 0; i < stringA.Length; i++) {
                for (int j = 0; j < stringB.Length; j++) {
                    // If same char and i or j is 0, match is 1 (start of string). If same char and i and j non-zero,
                    // increment match value at last i & j by 1. Otherwise, if characters differ, set match to 0.

                    match[i, j] = (stringA[i] == stringB[j]) ? ((i == 0 || j == 0) ? 1 : match[i - 1, j - 1] + 1) : 0;

                    if (match[i, j] > overlapSize) {
                        overlapSize = match[i, j]; // New maximum overlap size
                        int newOverlapIndex = i - match[i, j] + 1;
                        if (newOverlapIndex != overlapIndex) { // Clear list, set new starting index
                            overlapChar.Clear();
                            overlapIndex = newOverlapIndex;
                        }
                        overlapChar.Add(stringA[i]);
                    }
                }
            }
            string overlap = String.Join("", overlapChar);
            return overlap;
        }

        public static String Merge()
        {
            // Take two strings as argument, merge contents based on the overlap, return single merged string
            // If overlap equal to full length of a string, consider string merged and return larger string
            string mergedString = "";
            return mergedString;
        }
    }
}
