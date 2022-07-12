namespace CSharp.leetCode; 

public static class ClimbStairs {
    /// <summary>
    /// https://leetcode.com/problems/climbing-stairs/
    /// You are climbing a staircase. It takes n steps to reach the top.
    /// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    /// </summary>
    public static int Solve(int n) => Fib(n + 1);
    
    private static int Fib(int n) {
        int[] cache = new int[n + 1];
        return Fib(n, cache);
    }
    
    private static int Fib(int n, int[] cache) {
        if (n <= 1) return n;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Fib(n - 1, cache) + Fib(n - 2, cache);
    }
}