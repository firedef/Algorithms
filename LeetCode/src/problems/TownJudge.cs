namespace LeetCode.problems; 

public static class TownJudge {
    /// <summary>
    /// https://leetcode.com/problems/find-the-town-judge/
    /// In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge. <br/><br/>
    /// If the town judge exists, then:<br/>
    /// - The town judge trusts nobody.<br/>
    /// - Everybody (except for the town judge) trusts the town judge.<br/>
    /// - There is exactly one person that satisfies properties 1 and 2.<br/><br/>
    /// You are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi.<br/>
    /// Return the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.
    /// </summary>
    public static int Solve(int n, int[][] trust) {
        ushort[] outcomeTrust = new ushort[n];
        ushort[] incomeTrust = new ushort[n];

        foreach (int[] t in trust) {
            incomeTrust[t[1] - 1]++;
            outcomeTrust[t[0] - 1]++;
        }

        int judgeIndex = -1;
        for (int i = 0; i < n; i++) {
            bool isJudge = outcomeTrust[i] == 0 && incomeTrust[i] == n - 1;
            if (!isJudge) continue;
            if (judgeIndex != -1) return -1;
            judgeIndex = i + 1;
        }

        return judgeIndex;
    }
}