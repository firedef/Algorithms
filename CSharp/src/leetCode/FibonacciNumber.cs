namespace CSharp.leetCode; 

public static class FibonacciNumber {
    /// <summary>
    /// https://leetcode.com/problems/fibonacci-number/
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such
    /// that each number is the sum of the two preceding ones, starting from 0 and 1
    /// </summary>
    public static int Solve(int n) => Fib_Iterative(n);
    
    private static int Fib(int n, int[] cache) {
        if (n <= 1) return n;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Fib(n - 1, cache) + Fib(n - 2, cache);
    }

    private static int Fib_Iterative(int n) {
        if (n <= 1) return n;
        int[] nums = { 0, 1 };
        for (int i = 2; i <= n; i++)
            nums[i % 2] = nums[0] + nums[1];
        return nums[n % 2];
    }
}