using System;
using System.Linq;

namespace ConsoleApplication
{
    public class FragmentConstructor
    {
        String fragments[] = {
            "Lorem ipsu", "psum dolor sit amet", "sit a", "it amet consectetur", "r adipiscing elit"
        }; // Five fragments comprising the first line of Lorem Ipsum

        public static void Main(string[] fragments)
        {
            var checkedFragments = CheckFragments(fragments);
            int i = 0;
            for (i < checkedFragments.Max(); i++) {
                int j = i + 1;
                for (j < checkedFragments.Max(); j++) {
                    // Need some method of storing size of intersect along with value of i and j so we can return to
                    // them later for merging
                    // 3-value dictionary? Contains string a, string b, and string overlap (can get integer overlap
                    // from str overlap.Length)
                }
            }
        }

        public static String[] CheckFragments(fragments)
        {
            // Perform sanity checking on sentence fragments (i.e. size < 1000 characters, characters valid)
            return checkedFragments;
        }

        public static String Overlap()
        {
            // Run Enumerable.Intersect comparisons here
            // Take two strings as argument, check if overlap between the two, return substring of overlapped chars
            return overlap;
        }

        public static String Merge()
        {
            // Take two strings as argument, merge contents based on the overlap, return single merged string
            // If overlap equal to full length of a string, consider string merged and return larger string
            return mergedString;
        }
    }
}
