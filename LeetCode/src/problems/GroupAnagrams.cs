namespace LeetCode.problems; 

public static class GroupAnagrams {
    /// <summary>
    /// https://leetcode.com/problems/group-anagrams/
    /// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once
    /// </summary>
    public static IList<IList<string>> Solve(string[] strs) {
        int len = strs.Length;

        Dictionary<string, int> map = new();
        List<IList<string>> anagrams = new();

        for (int i = 0; i < len; i++) {
            string s = new(strs[i].OrderBy(v => v).ToArray());
            if (map.TryGetValue(s, out int p)) {
                anagrams[p].Add(strs[i]);
                continue;
            }
            
            map.Add(s, anagrams.Count);
            anagrams.Add(new List<string> {strs[i]});
        }

        return anagrams;
    }
}