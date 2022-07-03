namespace LeetCode.twoSum; 

public static class TwoSum {
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// </summary>
    public static int[] Solution(int[] nums, int target) {
        int len = nums.Length;

        for (int i = 0; i < len; i++) {
            int findV = target - nums[i];

            for (int j = 0; j < len; j++)
                if (nums[j] == findV && i != j) return new[] {i, j};
        }

        return new[] { -1, -1 };
    }
}