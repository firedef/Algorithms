namespace LeetCode.problems; 

/// <summary>
/// https://leetcode.com/problems/lfu-cache/
/// Design and implement a data structure for a Least Frequently Used (LFU) cache. <br/><br/>
/// Implement the LFUCache class:<br/>
/// - LFUCache(int capacity) Initializes the object with the capacity of the data structure.<br/>
/// - int get(int key) Gets the value of the key if the key exists in the cache. Otherwise, returns -1.<br/>
/// - void put(int key, int value) Update the value of the key if present, or inserts the key if not already present. When the<br/>
/// cache reaches its capacity, it should invalidate and remove the least frequently used key before inserting a new item. For this
/// problem, when there is a tie (i.e., two or more keys with the same frequency), the least recently used key would be invalidated<br/><br/>.
/// To determine the least frequently used key, a use counter is maintained for each key in the cache. The
/// key with the smallest use counter is the least frequently used key.<br/><br/>
/// When a key is first inserted into the cache, its use counter is set
/// to 1 (due to the put operation). The use counter for a key in the cache is incremented either a get or put operation is called on it.<br/><br/>
/// The functions get and put must each run in O(1) average time complexity.
/// </summary>
public class LFUCache {
    private readonly Dictionary<int, (int val, int count)> _items;
    private readonly List<LinkedList<int>> _counts = new();

    private readonly int _capacity;
    private int _count;
    private int _minCount;

    public LFUCache(int capacity) {
        _capacity = capacity;
        _items = new(capacity);
        _counts.Add(new());
    }

    private void Ref(int key) {
        (int v, int c) item = _items[key];
        _counts[item.c].Remove(key);

        if (_counts.Count <= item.c + 1) _counts.Add(new());
        _counts[item.c + 1].AddFirst(key);

        if (_counts[_minCount].Count == 0 && _counts.Count > _minCount + 1) _minCount++;

        item.c++;
        _items[key] = item;
    }

    private void RemoveLeastFrequentlyUsed() {
        _items.Remove(_counts[_minCount].Last!.Value);
        _counts[_minCount].RemoveLast();
        if (_counts[_minCount].Count == 0 && _counts.Count > _minCount + 1) _minCount++;
        _count--;
    }

    public int Get(int key) {
        if (!_items.TryGetValue(key, out (int val, int count) val)) return -1;
        Ref(key);
        return val.val;
    }

    public void Put(int key, int value) {
        if (_capacity == 0) return;
        
        if (_items.TryGetValue(key, out (int val, int count) val)) {
            val.val = value;
            _items[key] = val;
            Ref(key);
            return;
        }

        if (_count >= _capacity) RemoveLeastFrequentlyUsed();

        _items.Add(key, (value, 0));
        _counts[0].AddFirst(key);

        _minCount = 0;
        _count++;
    }
}