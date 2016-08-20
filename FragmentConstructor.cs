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
            for (int i = 0; i < length; i++) {
                for (int j = i + 1; j < length; j++) {
                    // Need some method of storing size of intersect along with value of i and j so we can return to
                    // them later for merging
                    // 3-value dictionary? Contains string a, string b, and string overlap (can get integer overlap
                    // from str overlap.Length)
                    // Order the dictionary in descending size of overlap
                    // Overwrite dictionary for each iteration (given the merge will require new overlaps)
                    string overlap = Overlap(checkedFragments[i], checkedFragments[j]);
                    overlapCheck.Add(Tuple.Create(checkedFragments[i], checkedFragments[j], overlap, overlap.Length));
                }
                // Now sort overlapCheck by descending size of overlap.Length (Tuple.Item4)
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

        public static String Overlap(stringA, stringB)
        {
            // Run Enumerable.Intersect comparisons here
            // Take two strings as argument, check if overlap between the two, return substring of overlapped chars
            IEnumerable<string> overlap = stringA.Intersect(stringB);
            if (overlap.IsNullOrEmpty) {
                overlap = "";
            }
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
