namespace LeetCode.problems;

/// <summary>
/// https://leetcode.com/problems/operations-on-tree/
/// You are given a tree with n nodes numbered from 0 to n - 1 in the form of a parent array parent where parent[i] is the parent of the ith node.
/// The root of the tree is node 0, so parent[0] = -1 since it has no parent. You want to design a data structure that allows users to lock, unlock, and upgrade nodes in the tree.
/// The data structure should support the following functions:
/// - Lock: Locks the given node for the given user and prevents other users from locking the same node. You may only lock a node using this function if the node is unlocked.
/// - Unlock: Unlocks the given node for the given user. You may only unlock a node using this function if it is currently locked by the same user.
/// - Upgrade: Locks the given node for the given user and unlocks all of its descendants regardless of who locked it. You may only upgrade a node if all 3 conditions are true:
///     - The node is unlocked,
///     - It has at least one locked descendant (by any user), and
///     - It does not have any locked ancestors.
/// 
/// Implement the LockingTree class:
/// - LockingTree(int[] parent) initializes the data structure with the parent array.
/// - lock(int num, int user) returns true if it is possible for the user with id user to lock the node num, or false otherwise. If it is possible, the node num will become locked by the user with id user.
/// - unlock(int num, int user) returns true if it is possible for the user with id user to unlock the node num, or false otherwise. If it is possible, the node num will become unlocked.
/// - upgrade(int num, int user) returns true if it is possible for the user with id user to upgrade the node num, or false otherwise. If it is possible, the node num will be upgraded.
/// </summary>
public class LockingTree {
    private readonly Node[] _nodes;

    public LockingTree(params int[] parents) {
        int len = parents.Length;
        _nodes = new Node[len];
        for (int i = 0; i < len; i++)
            _nodes[i] = new();
        
        for (int i = 0; i < len; i++) {
            int parentId = parents[i];
            _nodes[i].parent = parentId == -1 ? null : _nodes[parentId];
            _nodes[i].parent?.childs.Add(_nodes[i]);
        }
    }

    public bool Lock(int num, int user) {
        if (_nodes[num].lockedBy != 0) return false;
        _nodes[num].lockedBy = user;
        return true;
    }

    public bool Unlock(int num, int user) {
        if (_nodes[num].lockedBy != user) return false;
        _nodes[num].lockedBy = 0;
        return true;
    }

    public bool Upgrade(int num, int user) {
        Node node = _nodes[num];
        if (node.isLocked) return false;
        if (HasLockedAncestors(node)) return false;
        if (!HasLockedDescendants(node)) return false;
        
        UnlockDescendants(node);
        node.lockedBy = user;
        return true;
    }
    
    private bool HasLockedAncestors(Node node) {
        while (node.parent != null) {
            node = node.parent;
            if (node.isLocked) return true;
        }

        return false;
    }

    private bool HasLockedDescendants(Node node) {
        Queue<Node> stack = new();
        foreach (Node child in node.childs) 
            stack.Enqueue(child);

        while (stack.Count > 0) {
            node = stack.Dequeue();
            if (node.isLocked) return true;
            foreach (Node child in node.childs) 
                stack.Enqueue(child);
        }

        return false;
    }

    private void UnlockDescendants(Node node) {
        Stack<Node> stack = new();
        foreach (Node child in node.childs) 
            stack.Push(child);

        while (stack.Count > 0) {
            node = stack.Pop();
            node.lockedBy = 0;
            foreach (Node child in node.childs) 
                stack.Push(child);
        }
    }

    public class Node {
        public Node? parent = null;
        public readonly List<Node> childs = new();
        public int lockedBy = 0;
        public bool isLocked => lockedBy != 0;
    }
}