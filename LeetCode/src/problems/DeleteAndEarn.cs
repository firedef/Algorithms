namespace LeetCode.problems; 

public static class DeleteAndEarn {
    public static int Solve(int[] nums) {
        int numsCount = nums.Length;
        int maxElement = nums.Max();
        
        int[] frqArr = new int[maxElement + 1];
        for (int i = 0; i < numsCount; i++)
            frqArr[nums[i]]++;

        int[] cached = new int[maxElement + 1];
        for (int i = 0; i <= maxElement; i++)
            cached[i] = -1;

        int maxPoints = 0;
        for (int i = 0; i <= maxElement; i++)
            maxPoints = Math.Max(maxPoints, CalculateEarn(i, frqArr, cached));
        return maxPoints;
    }

    private static int CalculateEarn(int x, int[] frqArr, int[] cached) {
        if (x == 0) return 0;
        if (cached[x] != -1) return cached[x];
        
        int onTake = frqArr[x] * x;
        if (x > 1) onTake += CalculateEarn(x - 2, frqArr, cached);

        int onSkip = CalculateEarn(x - 1, frqArr, cached);

        return cached[x] = Math.Max(onTake, onSkip);
    }
}