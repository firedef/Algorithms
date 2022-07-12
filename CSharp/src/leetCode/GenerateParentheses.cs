namespace CSharp.leetCode; 

public static class GenerateParentheses {
    /// <summary>
    /// https://leetcode.com/problems/generate-parentheses/
    /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    /// </summary>
    public static IList<string> Solve(int n) {
        string[][] variants = new string[n+1][];
        variants[0] = new[] { "" };

        // solve for every previous case
        for (int i = 0; i < n; i++) {
            string[] cur = new string[_catalanNumbers[i + 1]];
            int pos = 0;

            // combine previous solutions
            // fN = (f0)fN-1, (f1)fN-2, ... (fI)fN-I-1
            for (int j = 0; j <= i; j++) 
                foreach (string left in variants[j])
                    foreach (string right in variants[i - j])
                        cur[pos++] = $"({left}){right}";
            
            variants[i+1] = cur;
        }

        // return last calculated solution
        return variants[^1];
    }

    // catalan sequence numbers ( (2n)! / ((n + 1)! ) from 0 to 19
    private static readonly int[] _catalanNumbers = {
        0, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790,
        477638700, 1767263190
    };
}