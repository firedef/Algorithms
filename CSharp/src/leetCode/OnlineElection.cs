namespace CSharp.leetCode; 

/// <summary>
/// You are given two integer arrays persons and times. In an election, the ith vote was cast for persons[i] at time times[i].
/// For each query at a time t, find the person that was leading the election at time t. Votes cast at time t will count towards
/// our query. In the case of a tie, the most recent vote (among tied candidates) wins. <br/><br/>
/// Implement the TopVotedCandidate class: <br/>
/// - TopVotedCandidate(int[] persons, int[] times) Initializes the object with the persons and times arrays <br/>
/// - int q(int t) Returns the number of the person that was leading the election at time t according to the mentioned rules.
/// </summary>
public class OnlineElection {
    private readonly int[] _persons;
    private readonly int[] _times;
    private readonly int _maxPersonId;
    
    public OnlineElection(int[] persons, int[] times) {
        _persons = persons;
        _times = times;
        _maxPersonId = persons.Distinct().Max();
    }

    public int Q(int t) {
        int[] votes = new int[_maxPersonId + 1];
        int[] lastVote = new int[_maxPersonId + 1];

        for (int i = 0; i < _times.Length; i++) {
            int time = _times[i];
            if (time > t) break;

            votes[_persons[i]]++;
            lastVote[_persons[i]] = i;
        }

        int maxV = -1;
        int maxI = 0;

        for (int i = 0; i <= _maxPersonId; i++) {
            if (votes[i] < maxV) continue;
            if (votes[i] == maxV && lastVote[i] < lastVote[maxI]) continue; 
            maxV = votes[i];
            maxI = i;
        }

        return maxI;
    }
}