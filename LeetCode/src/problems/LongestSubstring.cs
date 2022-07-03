namespace LeetCode.problems; 

public static class LongestSubstring {
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// </summary>
    public static int Solve(string s) {
        int l = s.Length;

        int longest = 0;
        for (int i = 0; i < l - longest; i++)
            longest = Math.Max(longest, LongestSubstringAt(i, s));
        
        return longest;
    }

    private static int LongestSubstringAt(int i, string s) {
        int l = s.Length;
        HashSet<char> present = new();
        
        int j = 0;
        for (; i < l; j++, i++)
            if (!present.Add(s[i])) return j;
        return j;
    }
}