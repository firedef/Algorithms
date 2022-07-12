namespace CSharp.leetCode; 

public static class GoodPairs {
    /// <summary>
    /// https://leetcode.com/problems/number-of-good-pairs/
    /// Given an array of integers nums, return the number of good pairs.
    /// A pair (i, j) is called good if nums[i] == nums[j] and i < j
    /// </summary>
    public static int Solve(int[] nums) {
        int len = nums.Length;
        int c = 0;
        for (int i = 0; i < len; i++)
            c += CountGoodPairsFor(i, nums);
        return c;
    }

    private static int CountGoodPairsFor(int i, int[] nums) {
        int len = nums.Length;
        int c = 0;
        int v = nums[i];
        for (int j = i + 1; j < len; j++)
            if (nums[j] == v)
                c++;
        return c;
    }
}