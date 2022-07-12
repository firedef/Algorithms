namespace CSharp.leetCode; 

/// <summary>
/// https://leetcode.com/problems/lru-cache/
/// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache. <br/> <br/>
/// Implement the LRUCache class: <br/>
/// - LRUCache(int capacity) Initialize the LRU cache with positive size capacity. <br/>
/// - int get(int key) Return the value of the key if the key exists, otherwise return -1. <br/>
/// - void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If
/// the number of keys exceeds the capacity from this operation, evict the least recently used key. <br/> <br/>
/// The functions get and put must each run in O(1) average time complexity.
/// </summary>
public class LRUCache {
    private readonly Dictionary<int, (LinkedListNode<int> node, int val)> _map;
    private readonly LinkedList<int> _list;
    private readonly int _capacity;
    private int _count;

    public int count => _count;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _map = new(capacity);
        _list = new();
    }

    private void MoveToStart(LinkedListNode<int> node) {
        _list.Remove(node);
        _list.AddFirst(node);
    }

    private void RemoveLast() {
        _map.Remove(_list.Last!.Value);
        _list.RemoveLast();
        _count--;
    }

    private void Add(int key, int val) {
        _map.Add(key, (_list.AddFirst(key), val));
        _count++;
    }

    public int Get(int key) {
        if (!_map.TryGetValue(key, out (LinkedListNode<int> node, int val) val)) return -1;
        
        MoveToStart(val.node);
        return val.val;
    }

    public void Put(int key, int value) {
        if (_map.TryGetValue(key, out (LinkedListNode<int> node, int val) val)) {
            MoveToStart(val.node);
            val.val = value;
            _map[key] = val;
            return;
        }

        if (_count >= _capacity) RemoveLast();
        Add(key, value);
    }

    public void Remove(int key) {
        if (!_map.Remove(key, out (LinkedListNode<int> node, int val) val)) return;
        _list.Remove(val.node);
        _count--;
    }
}