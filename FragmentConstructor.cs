using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    public class FragmentConstructor
    {
        public static String[] fragments = new String[] {
            "it amet consectetu",
            "sit am",
            "psum dolor sit amet",
            "etur adipiscing elit",
            "Lorem ipsum ",
            ". Quisque egestas vestibulum ligula nec tincidunt velit semper in"
        }; // 6 fragments comprising the first line of Lorem Ipsum

        public static void Main()
        {
            var overlapCheck = new List<Tuple<string, string, string, int>>();
            String[] checkedFragments = CheckFragments(fragments);
            int length = checkedFragments.Length;

            while (length > 1) {
                for (int i = 0; i < length; i++) {
                    for (int j = i + 1; j < length; j++) {
                        string overlap = Overlap(checkedFragments[i], checkedFragments[j]);
                        overlapCheck.Add(Tuple.Create(checkedFragments[i], checkedFragments[j], overlap, overlap.Length));
                    }
                }
                // Now sort overlapCheck by descending size of overlap.Length (Tuple.Item4)

                overlapCheck.Sort((x, y) => y.Item4.CompareTo(x.Item4));
                checkedFragments = Merge(
                    overlapCheck[0].Item1, overlapCheck[0].Item2, overlapCheck[0].Item3, checkedFragments);
                overlapCheck.Clear(); // Remove all items for fresh comparison of remaining strings
                length = checkedFragments.Length; // Update length to reflect updated array
            }
            Console.WriteLine(String.Join("", checkedFragments));
        }

        public static String[] CheckFragments(String[] fragments)
        {
            // Perform sanity checking on fragments (i.e. array less than 5000 elements, strings less than 1000 chars)
            int length = fragments.Length;
            if (length > 5000) {
                throw new ArgumentException(@"Array has too many elements: {0}\n
                    Please reduce this to 5000 or less", length.ToString());
            }
            List<string> list = new List<string>();

            for (int i = 0; i < length; i++) {
                if (fragments[i].Length < 1000 && fragments[i].Length > 0) {
                    list.Add(fragments[i]);
                }
                else {
                    throw new ArgumentException(@"Array contains a string of invalid length: {0}\n
                        Please ensure string lengths are between 1 and 1000 characters", fragments[i]);
                }
            }
            return list.ToArray();
        }

        public static String Overlap(string strA, string strB)
        {
            // Take two strings as argument, check if overlap between the two, return substring of overlapped chars

            int[,] match = new int[strA.Length, strB.Length];
            int overlapIndex = 0, newOverlapIndex;
            StringBuilder sb = new StringBuilder();
            List<String> sbList = new List<String>();

            for (int i = 0; i < strA.Length; i++) {
                for (int j = 0; j < strB.Length; j++) {
                    // If same char and i or j is 0, match is 1 (start of string). If same char and i and j non-zero,
                    // increment match value at last i & j by 1. Otherwise, if characters differ, set match to 0.

                    if (strA[i] != strB[j]) {
                        match[i, j] = 0;
                    }
                    else {
                        match[i, j] = (i == 0 || j == 0) ? 1 : 1 + match[i - 1, j - 1];

                        newOverlapIndex = i - match[i, j] + 1;

                        if (match[i, j] >= 2) {
                            // Clear list, set new starting index, recreate overlap substring from prior index
                            sb.Length = 0;
                            overlapIndex = newOverlapIndex;
                            sb.Append(strA.Substring(overlapIndex, (i + 1) - overlapIndex));

                            if (!sbList.Contains(sb.ToString())) {
                                sbList.Add(sb.ToString());
                            }
                        }
                    }
                }
            }
            if (!sbList.Contains(sb.ToString())) { sbList.Add(sb.ToString()); }
            return CheckOverlapList(sbList, strA, strB);
        }

        public static string CheckOverlapList(List<String> list, string strA, string strB)
        {
            // Check validity of overlap; i.e. does it occur at beginning of one string and end of the other, or is the
            // overlap equal to one of the comparison strings?
            int i = 0;
            list.Sort((x, y) => y.Length.CompareTo(x.Length));
            if (list.Count >= 1) {
                while (i < list.Count){
                    string s = list[i];
                    if ((strA.StartsWith(s) && strB.EndsWith(s)) ||
                        (strB.StartsWith(s) && strA.EndsWith(s)) ||
                        (s == strA || s == strB))
                    {
                        return s;
                    }
                    else {
                        i++;
                    }
                }
            }
            // If list empty, can say there is zero overlap
            return "";
        }

        public static String[] Merge(string strA, string strB, string overlap, string[] fragments)
        {
            // Take two strings as argument, merge contents based on the overlap, return single merged string
            // If overlap equal to full length of a string, consider string merged
            string merged = "", leftover = "", removed = "";
            if (overlap == strA) {
                removed = strA;
            }
            else if (overlap == strB) {
                removed = strB;
            }
            else {
                if (strA.EndsWith(overlap) && strB.StartsWith(overlap)) { // First string in sequence is stringA
                    string newA = strA.Remove((strA.Length - overlap.Length), overlap.Length);
                    merged = String.Join("", newA, strB);
                    leftover = strA;
                    removed = strB;
                }
                else if (strB.EndsWith(overlap) && strA.StartsWith(overlap)) { // First string in sequence is stringB
                    string newB = strB.Remove((strB.Length - overlap.Length), overlap.Length);
                    merged = String.Join("", newB, strA);
                    leftover = strB;
                    removed = strA;
                }
                else { // Case where overlap is 0; ordering is irrelevant (only occurs if no other merge is possible)
                    merged = String.Join("", strA, strB);
                    leftover = strA;
                    removed = strB;
                }
            }
            return ReplaceItem(merged, leftover, removed, fragments);
        }

        public static String[] ReplaceItem(string merged, string leftover, string removed, string[] fragments)
        {
            List<string> list = new List<string>(fragments);
            int length = fragments.Length;
            bool replaced = false;

            for (int i = 0; i < length; i++) {
                if (fragments[i] == leftover || fragments[i] == removed) {
                    list.RemoveAt(i);

                    if (!String.IsNullOrWhiteSpace(merged) && !replaced) {
                        // Check string to be merged is valid, and that it hasn't already been inserted into the array
                        list.Insert(i, merged);
                        replaced = true;
                    }
                    length = fragments.Length;
                }
            }
            return list.ToArray();
        }
    }
}
