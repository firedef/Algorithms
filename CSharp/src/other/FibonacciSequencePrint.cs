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
        BigInteger[] arr = FibArr(offset + n);

        for (int i = 0; i < n; i++)
            Console.WriteLine($"fib({i + offset}): {arr[i + offset]}");
    }
    
    private static BigInteger Fib(int n, BigInteger[] cache) {
        if (n <= 1) return n;
        if (cache[n] != 0) return cache[n];
        return cache[n] = Fib(n - 2, cache) + Fib(n - 1, cache);
    }
}