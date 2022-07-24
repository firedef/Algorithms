using System.Diagnostics;
using System.Numerics;

namespace CSharp.other; 

public static class FibonacciSequencePrint {
    public static BigInteger Fib(int n) {
        BigInteger[] cache = new BigInteger[n + 1];
        return Fib(n, cache);
    }

    public static BigInteger[] FibArr(int n) {
        BigInteger[] cache = new BigInteger[n + 1];
        Fib(n, cache);
        return cache;
    }

    public static void PrintArr(int offset, int n) {
        BigInteger[] nums = { 0, 1 };
        
        while (offset < 1 && n > 1) {
            Console.WriteLine($"fib({offset}): {nums[offset % 2]}");
            offset++;
            n--;
        }
        
        for (int i = 2; i < offset; i++)
            nums[i % 2] = nums[0] + nums[1];
        
        for (int i = offset; i < offset + n; i++)
            Console.WriteLine($"fib({i}): {nums[i % 2] = nums[0] + nums[1]}");
        ;
    }
    
    private static BigInteger Fib(int n, BigInteger[] cache) {
        if (n <= 1) return n;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Fib(n - 2, cache) + Fib(n - 1, cache);
    }
    
    private static BigInteger Fib_Iterative(int n) {
        BigInteger[] nums = { 0, 1 };
        for (int i = 2; i <= n; i++)
            nums[i % 2] = nums[0] + nums[1];
        return nums[n % 2];
    }
}