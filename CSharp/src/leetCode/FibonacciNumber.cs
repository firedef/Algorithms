namespace CSharp.leetCode; 

public static class FibonacciNumber {
    /// <summary>
    /// https://leetcode.com/problems/fibonacci-number/
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such
    /// that each number is the sum of the two preceding ones, starting from 0 and 1
    /// </summary>
    public static int Solve(int n) {
        int[] cache = new int[n + 1];
        return Fib(n, cache);
    }
    
    private static int Fib(int n, int[] cache) {
        if (n <= 1) return n;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Fib(n - 1, cache) + Fib(n - 2, cache);
    }
}