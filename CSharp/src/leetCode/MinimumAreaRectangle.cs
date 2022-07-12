namespace CSharp.leetCode; 

public static class MinimumAreaRectangle {
    /// <summary>
    /// https://leetcode.com/problems/minimum-area-rectangle/
    /// You are given an array of points in the X-Y plane points where points[i] = [xi, yi].
    /// Return the minimum area of a rectangle formed from these points, with sides parallel to the X and Y axes. If there is not any such rectangle, return 0.
    /// </summary>
    public static int Solve(int[][] points) {
        HashSet<Point> set = MakeHashSet(points);
        
        int minArea = int.MaxValue;

        int len = points.Length;

        for (int i = 0; i < len; i++) {
            Point p0 = new(points[i]);
            
            for (int j = 0; j < len; j++) {
                if (i == j) continue;
                Point p1 = new(points[j]);
                int area = Math.Abs((p0.x - p1.x) * (p0.y - p1.y));
                if (area == 0 || area >= minArea) continue;

                Point p2 = new(p0.x, p1.y);
                Point p3 = new(p1.x, p0.y);
                if (!set.Contains(p2) || !set.Contains(p3)) continue;

                minArea = area;
            }
        }
        
        return minArea == int.MaxValue ? 0 : minArea;
    }

    private static HashSet<Point> MakeHashSet(int[][] points) {
        HashSet<Point> set = new();
        foreach (int[] p in points)
            set.Add(new(p));
        return set;
    }

    private record struct Point(int x, int y) {
        public int x = x;
        public int y = y;

        public Point(int[] arr) : this(arr[0], arr[1]) { }
    }
}