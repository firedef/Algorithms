namespace CSharp.leetCode; 

public static class MedianOfTwoSortedArrays {
    public static double Solve(int[] nums1, int[] nums2) {
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        int totalLen = len1 + len2;

        if ((totalLen & 1) != 0)
            return ElementAt(nums1, nums2, totalLen >> 1);
        return (ElementAt(nums1, nums2, totalLen >> 1) + ElementAt(nums1, nums2, (totalLen >> 1) - 1)) / 2d;
    }

    private static int ElementAt(int[] nums1, int[] nums2, int el) {
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        int index1 = 0;
        int index2 = 0;
        
        int num = 0;
        for (int i = 0; i <= el; i++) {
            if (index1 >= len1) return nums2[el + index2 - i];
            if (index2 >= len2) return nums1[el + index1 - i];
            
            bool isSmaller = nums1[index1] < nums2[index2];
            if (isSmaller) {
                num = nums1[index1];
                index1++;
                continue;
            }
            num = nums2[index2];
            index2++;
        }

        return num;
    }
}