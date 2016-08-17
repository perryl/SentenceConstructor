using System;
namespace SentenceConstructor
{
    static void Main() {
        int i = 0;
        for (i < checkedFragments.Max(); i++) {
            int j = i + 1;
            for (j < checkedFragments.Max(); j++) {
                // Run Enumerable.Intersect comparisons here
                // Need some method of storing size of intersect along with value of i and j so we can return to them later for merging
            }
        }
        string constructedSentence = 
    }

    static string Array {
        string fragments[] = new string[] {
            "Lorem ipsu", "psum dolor sit amet", "sit a", "it amet consectetur", "r adipiscing elit"
        }; // Five fragments comprising the first line of Lorem Ipsum
        int maxStringLength = 1000; // Maximum allowed number of characters
	List<string> list = new List<string>();
        for (int i = 0; i < fragments.Max(); i++) {
            if fragments[i].Length < maxStringLength && fragments[i].Length > 0 {
                list.Add(fragments[i]);
            }
        }
        string[] checkedFragments = list.ToArray();

        /* Double integer loop; set i = 0 and compare fragment[0] to each item in fragment[j] where j is originally set
        at i + 1 but increments with each comparison, to a maximum of the size of the fragments array. once j reaches
        increase i and rerun the process, starting once more with j = i + 1, as there is no need to repeat comparisons
        (i.e. fragment[1] <> fragment[2] and fragment[2] <> fragment[1]) */
    }
    
    static void Overlap {
        // Check overlap
        // Call merge function from here; keep functionality separate for readability
    }

    static void Merge {
        if Overlap == fragments[i].Length() {
            // Full string is subset of second string; can be considered merged
            // Remove item from list
        }
    }
}
