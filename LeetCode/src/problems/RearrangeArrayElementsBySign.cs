namespace LeetCode.problems; 

public static class RearrangeArrayElementsBySign {
    /// <summary>
    /// https://leetcode.com/problems/rearrange-array-elements-by-sign/
    /// You are given a 0-indexed integer array nums of even length consisting of an equal number of positive and negative integers. <br/>
    /// You should rearrange the elements of nums such that the modified array follows the given conditions: <br/>
    /// - Every consecutive pair of integers have opposite signs. <br/>
    /// - For all integers with the same sign, the order in which they were present in nums is preserved. <br/>
    /// - The rearranged array begins with a positive integer. <br/> <br/>
    /// Return the modified array after rearranging the elements to satisfy the aforementioned conditions.
    /// </summary>
    public static int[] Solve(int[] nums) {
        int len = nums.Length;
        int lenHalf = len >> 1;
        int[] positive = new int[lenHalf];
        int[] negative = new int[lenHalf];
        int posI = 0;
        int negI = 0;

        for (int i = 0; i < len; i++) {
            int num = nums[i];
            if (num >= 0) positive[posI++] = num;
            else negative[negI++] = num;
        }

        for (int i = 0; i < lenHalf; i++) {
            nums[i << 1] = positive[i];
            nums[(i << 1) + 1] = negative[i];
        }

        return nums;
    }
}