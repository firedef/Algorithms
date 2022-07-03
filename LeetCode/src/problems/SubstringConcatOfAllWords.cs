namespace LeetCode.problems; 

public static class SubstringConcatOfAllWords {
    /// <summary>
    /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/
    /// You are given a string s and an array of strings words of the same length. Return all starting indices of substring(s) in s that is a
    /// concatenation of each word in words exactly once, in any order, and without any intervening characters.
    /// You can return the answer in any order.
    /// </summary>
    public static IList<int> Solve(string s, string[] words) {
        int wordLength = words[0].Length;
        int wordCount = words.Length;
        int concatLength = wordCount * wordLength;
        int strLen = s.Length;

        List<int> indices = new();

        HashSet<char> wordStartChars = new(wordCount);
        for (int i = 0; i < wordCount; i++)
            wordStartChars.Add(words[i][0]);

        HashSet<int> checkedWords = new(wordCount);
        for (int i = 0; i < strLen - concatLength; i++) {
            if (!wordStartChars.Contains(s[i])) continue;
            checkedWords.Clear();

            for (int j = 0; j < wordCount; j++) {
                int checkIndex = i + j * wordLength;
                for (int k = 0; k < wordCount; k++) {
                    if (checkedWords.Contains(k)) continue;
                    
                    if (!ContainsAt(s, checkIndex, words[k])) continue;
                    checkedWords.Add(k);
                    goto NEXT_PART;
                }
                goto NOT_FOUND;
                
                NEXT_PART: ;
            }
            indices.Add(i);
            
            NOT_FOUND: ;
        }

        return indices;
    }

    private static bool ContainsAt(string s, int index, string word) {
        int wordLength = word.Length;

        for (int i = 0; i < wordLength; i++) 
            if (s[i + index] != word[i])
                return false;
        return true;
    }
}