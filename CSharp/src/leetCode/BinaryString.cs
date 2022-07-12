namespace CSharp.leetCode; 

public static class BinaryString {
    /// <summary>
    /// https://leetcode.com/problems/binary-string-with-substrings-representing-1-to-n/
    /// Given a binary string s and a positive integer n, return true if the binary representation of all the integers in the range [1, n] are substrings of s, or false otherwise.
    /// A substring is a contiguous sequence of characters within a string.
    /// </summary>
    public static bool Solution(string s, int n) {
        for (int i = 0; i <= n; i++)
            if (!ContainsBinary(s, i))
                return false;

        return true;
    }

    private static bool ContainsBinary(string s, int num) {
        int c = s.Length;
        int numC = (int)Math.Ceiling(Math.Log2(num + 1));

        for (int i = 0; i <= c - numC; i++) {
            for (int j = 0; j < numC; j++) {
                bool strBitSet = s[i + j] == '1';
                bool numBitSet = (num & (1 << (numC - 1 - j))) != 0;
                if (strBitSet != numBitSet) goto NOT_FOUND;
            }

            return true;
            
            NOT_FOUND: ;
        }

        return false;
    }
}