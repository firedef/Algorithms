namespace CSharp.leetCode; 

public static class WiggleSubsequence {
    /// <summary>
    /// https://leetcode.com/problems/wiggle-subsequence/
    /// A wiggle sequence is a sequence where the differences between successive numbers strictly alternate between positive and negative.
    /// The first difference (if one exists) may be either positive or negative. A sequence with one element and a sequence with two non-equal elements
    /// are trivially wiggle sequences.
    /// For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the differences (6, -3, 5, -7, 3) alternate between positive and negative.
    /// In contrast, [1, 4, 7, 2, 5] and [1, 7, 4, 5, 5] are not wiggle sequences. The first is not because its first two
    /// differences are positive, and the second is not because its last difference is zero.
    /// A subsequence is obtained by deleting some elements (possibly zero) from the original sequence, leaving
    /// the remaining elements in their original order.
    /// Given an integer array nums, return the length of the longest wiggle subsequence of nums.
    /// </summary>
    public static int Solve(int[] nums) {
        int len = nums.Length;

        bool prevIsPositiveDiff = false;
        int currentLength = 0;
        int checkNum = nums[0];
        for (int i = 1; i < len; i++) {
            int diff = nums[i] - checkNum;
            if (diff == 0) continue;
            bool isPositiveDiff = diff > 0;

            checkNum = prevIsPositiveDiff ? Math.Max(checkNum, nums[i]) : Math.Min(checkNum, nums[i]);
            if (currentLength == 0 || prevIsPositiveDiff != isPositiveDiff) {
                currentLength++;
                checkNum = nums[i];
            }

            prevIsPositiveDiff = isPositiveDiff;
        }

        return currentLength+1;
    }
}