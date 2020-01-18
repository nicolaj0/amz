using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionStr2Tree
    {
        public TreeNode Str2Tree(String s) {
            if (string.IsNullOrEmpty(s)) {
                return null;
            }
            // The node on the top of the stack is the newest parent node.
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode root = null;
            for (int i = 0; i < s.Length; ) {
                char c = s[i];
                // Build a new node when a number is encountered.
                if (c == '-' || (c >= '0' && c <= '9')) {
                    String val = "" + c;
                    while (i + 1 < s.Length && s[i+1] >= '0' && s[i+1] <= '9') {
                        val += s[i+1];
                        i++;
                    }
                    TreeNode node = new TreeNode(int.Parse(val));
                    // Assign the new node to either left or right depending on
                    // the situation.
                    if (root != null) {
                        if (root.left == null) {
                            root.left = node;
                        } else {
                            root.right = node;
                        }
                    }
                    stack.Push(node);
                } else if (c == '(') {
                    // A number (node/child) must be followed this '(',  so we need
                    // its parent.
                    root = stack.Peek();
                } else {
                    // The node on the top of the stack is done.
                    stack.Pop();
                }
                i++;
            }
            return stack.Pop();
        }
    }
}