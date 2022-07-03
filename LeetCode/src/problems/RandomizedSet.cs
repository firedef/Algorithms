namespace LeetCode.problems; 

public class RandomizedSet {
    private readonly List<int> _itemSet = new();
    private readonly HashSet<int> _hashSet = new();
    private readonly Random _random = new();

    public RandomizedSet() { }

    public bool Insert(int val) {
        if (!_hashSet.Add(val)) return false;
        _itemSet.Add(val);
        return true;
    }

    public bool Remove(int val) {
        if (!_hashSet.Remove(val)) return false;
        _itemSet.Remove(val);
        return true;
    }

    public int GetRandom() => _itemSet[_random.Next(_itemSet.Count)];
}