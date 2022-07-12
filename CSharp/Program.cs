using System.Diagnostics;
using CSharp.leetCode;

Console.WriteLine(StringInterleaving.Solve("aacaac", "aacaaeaac", "aacaaeaaeaacaac"));
Console.WriteLine(StringInterleaving.Solve("aabcc", "dbbca", "aadbbcbcac"));
Console.WriteLine(StringInterleaving.Solve("a", "b", "ba"));
Console.WriteLine(StringInterleaving.Solve("a", "b", "bb"));
Console.WriteLine(StringInterleaving.Solve("a", "", "a"));

Stopwatch sw = Stopwatch.StartNew();

Console.WriteLine(StringInterleaving.Solve(
    "abababababababababababababababababababababababababababababababababababababababababababababababababbb",
    "babababababababababababababababababababababababababababababababababababababababababababababababaaaba",
    "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb"));

Console.WriteLine(sw.ElapsedMilliseconds + "ms");

