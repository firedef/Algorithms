namespace LeetCode.problems; 

public static class TribonacciNumber {
    /// <summary>
    /// https://leetcode.com/problems/n-th-tribonacci-number/
    /// The Tribonacci sequence Tn is defined as follows:
    /// T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
    /// Given n, return the value of Tn.
    /// </summary>
    public static int Solve(int n) {
        int[] cache = new int[n+1];
        return Tribonacci(n, cache);
    }

    private static int Tribonacci(int n, int[] cache) {
        if (n <= 1) return n;
        if (n == 2) return 1;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Tribonacci(n - 1, cache) + Tribonacci(n - 2, cache) + Tribonacci(n - 3, cache);
    }
}