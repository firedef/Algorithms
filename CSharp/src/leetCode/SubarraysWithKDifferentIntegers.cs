namespace CSharp.leetCode; 

public static class SubarraysWithKDifferentIntegers {
    /// <summary>
    /// https://leetcode.com/problems/subarrays-with-k-different-integers/
    /// Given an integer array nums and an integer k, return the number of good subarrays of nums.
    /// A good array is an array where the number of different integers in that array is exactly k.
    /// For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.
    /// A subarray is a contiguous part of an array.
    /// </summary>
    public static int Solve(int[] nums, int k) {
        int inclusive = Subarrays(nums, k, true);
        if (k == 1) return inclusive;
        int exclusive = Subarrays(nums, k, false);
        return inclusive - exclusive;
    }

    private static int Subarrays(int[] nums, int k, bool inclusive) {
        int len = nums.Length;
        Dictionary<int, int> numberCount = new();
        int left = 0;
        int total = 0;

        for (int right = 0; right < len; right++) {
            Inc(numberCount, nums[right]);

            while (inclusive && numberCount.Count > k || !inclusive && numberCount.Count >= k)
                Dec(numberCount, nums[left++]);

            total += right - left + 1;
        }

        return total;
    }

    private static void Inc(Dictionary<int, int> dict, int k) {
        if (dict.TryGetValue(k, out int v)) dict[k] = v + 1;
        else dict.Add(k, 1);
    }
    
    private static void Dec(Dictionary<int, int> dict, int k) {
        int v = dict[k] - 1;
        if (v <= 0) dict.Remove(k);
        else dict[k] = v;
    }
}