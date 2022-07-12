namespace CSharp.leetCode; 

public static class StringInterleaving {
    /// <summary>
    /// ! BROKEN !
    /// https://leetcode.com/problems/interleaving-string/
    /// Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.
    /// An interleaving of two strings s and t is a configuration where they are divided into non-empty substrings such that:
    /// s = s1 + s2 + ... + sn
    /// t = t1 + t2 + ... + tm
    /// |n - m| &lt;= 1
    /// The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
    /// Note: a + b is the concatenation of strings a and b.
    /// </summary>
    public static bool Solve(string s1, string s2, string s3) {
        int l1 = s1.Length;
        int l2 = s2.Length;
        int l3 = s3.Length;
        
        if (l1 + l2 != l3) return false;

        int d = l1 + 1;
        bool[] data = new bool[d * (l2 + 1)+1];
        data[0] = true;
        
        for (int j = 1; j <= l2; j++)
            data[j] = data[j - 1] && s2[j - 1] == s3[j - 1];
        
        for (int i = 1; i <= l1; i++) {
            data[i * d] = data[(i - 1) * d] && s1[i - 1] == s3[i - 1];
            for (int j = 1; j <= l2; j++) 
                data[i * d + j] = (data[(i - 1) * d + j] && s1[i - 1] == s3[i + j - 1]) || 
                                  (data[i * d + j - 1]   && s2[j - 1] == s3[i + j - 1]);
        }

        return data[l1 * d + l2];
    }

    // private static bool Solve(string s1, string s2, string s3, int p1, int p2, int p3) {
    //     int l1 = s1.Length;
    //     int l2 = s2.Length;
    //     int l3 = s3.Length;
    //     
    //     if (l1 + l2 != l3) return false;
    //
    //     for (; p3 < l3; p3++) {
    //         char ch = s3[p3];
    //         if (p1 < l1 && p2 < l2 && s1[p1] == ch && s1[p1] == s2[p2])
    //             return Solve(s1, s2, s3, p1 + 1, p2, p3 + 1) || 
    //                    Solve(s1, s2, s3, p1, p2 + 1, p3 + 1);
    //         
    //         if (p1 < l1 && ch == s1[p1]) p1++;
    //         else if (p2 < l2 && ch == s2[p2]) p2++;
    //         else return false;
    //     }
    //
    //     return true;
    // }
}