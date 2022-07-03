namespace LeetCode.problems; 

public static class FibonacciNumber {
    /// <summary>
    /// https://leetcode.com/problems/fibonacci-number/
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such
    /// that each number is the sum of the two preceding ones, starting from 0 and 1
    /// </summary>
    public static int Solve(int n) {
        if (n <= 1) return n;
        return Solve(n - 1) + Solve(n - 2);
    }
}