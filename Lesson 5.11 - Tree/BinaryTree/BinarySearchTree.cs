using System.Linq;

namespace BinaryTree
{
    /// <summary>
    ///     Binary search tree condition - left child is always smaller than the root, right child is always bigger than the
    ///     root
    /// </summary>
    public class BinarySearchTree : IBinaryTree
    {
        public Node Root;

        public void Insert(int value)
        {
            var cursor = Root;
            while (cursor != null)
                if (value == cursor.Value)
                {
                    return;
                }

                else if (value > cursor.Value)
                {
                    if (cursor.RightChild == null)
                    {
                        cursor.RightChild = new Node(value);
                        return;
                    }

                    cursor = cursor.RightChild;
                }
                else
                {
                    if (cursor.LeftChild == null)
                    {
                        cursor.LeftChild = new Node(value);
                        return;
                    }

                    cursor = cursor.LeftChild;
                }
        }

        public void Delete(int value)
        {
            var parent = Root;
            var cursor = Root;
            var goneRight = false;
            while (cursor != null)
                if (cursor.Value == value)
                {
                    var carryL = cursor.LeftChild;
                    var carryR = cursor.RightChild;

                    if (parent == cursor)
                    {
                        if (cursor.LeftChild != null)
                        {
                            Root = cursor.LeftChild;
                            if (carryR != null) Insert(carryR);
                        }
                        else if (cursor.RightChild != null)
                        {
                            Root = cursor.RightChild;
                            if (carryL != null) Insert(carryL);
                        }
                        else
                        {
                            Root = null;
                        }
                    }
                    else
                    {
                        if (goneRight)
                            parent.RightChild = null;
                        else
                            parent.LeftChild = null;
                        if (carryL != null) Insert(carryL);
                        if (carryR != null) Insert(carryR);
                    }

                    return;
                }
                else if (value < cursor.Value)
                {
                    parent = cursor;
                    cursor = cursor.LeftChild;
                    goneRight = false;
                }
                else
                {
                    parent = cursor;
                    cursor = cursor.RightChild;
                    goneRight = true;
                }
        }

        public bool Search(int value)
        {
            var cursor = Root;
            while (cursor != null)
                if (value < cursor.Value)
                {
                    if (cursor.LeftChild == null)
                        return false;
                    cursor = cursor.LeftChild;
                }
                else if (value > cursor.Value)
                {
                    if (cursor.RightChild == null)
                        return false;
                    cursor = cursor.RightChild;
                }
                else
                {
                    return true;
                }

            return false;
        }

        public int SubtreeMin(Node start)
        {
            var cursor = Root;
            while (cursor.LeftChild != null) cursor = cursor.LeftChild;
            return cursor.Value;
        }

        public int[] PreOrderTraversal()
        {
            return PreOrderTraversalFromNode(Root);
        }

        public int[] InOrderTraversal()
        {
            return InOrderTraversalFromNode(Root);
        }

        public int[] PostOrderTraversal()
        {
            return PostOrderTraversalFromNode(Root);
        }

        public int[] LevelOrderTraversal()
        {
            int[] z = { };
            for (var i = 0;; i++)
            {
                var next = LevelOrderTraversalFromNodeByDepth(Root, i);
                if (next.Length == 0) break;
                z = z.Concat(next).ToArray();
            }

            return z;
        }

        public override string ToString()
        {
            return Root.ToString();
        }

        private void Insert(Node carryR)
        {
            var cursor = Root;
            while (cursor != null)
                if (carryR.Value == cursor.Value)
                {
                    return;
                }

                else if (carryR.Value > cursor.Value)
                {
                    if (cursor.RightChild == null)
                    {
                        cursor.RightChild = new Node(carryR.Value);
                        return;
                    }

                    cursor = cursor.RightChild;
                }
                else
                {
                    if (cursor.LeftChild == null)
                    {
                        cursor.LeftChild = new Node(carryR.Value);
                        return;
                    }

                    cursor = cursor.LeftChild;
                }
        }

        private int[] PreOrderTraversalFromNode(Node start)
        {
            int[] left = { };
            int[] right = { };
            if (start.LeftChild != null) left = PreOrderTraversalFromNode(start.LeftChild);
            if (start.RightChild != null) right = PreOrderTraversalFromNode(start.RightChild);

            var z = new int[left.Length + right.Length + 1];
            z[0] = start.Value;
            left.CopyTo(z, 1);
            right.CopyTo(z, left.Length + 1);
            return z;
        }

        private int[] InOrderTraversalFromNode(Node start)
        {
            int[] left = { };
            int[] right = { };
            if (start.LeftChild != null) left = InOrderTraversalFromNode(start.LeftChild);
            if (start.RightChild != null) right = InOrderTraversalFromNode(start.RightChild);

            var z = new int[left.Length + right.Length + 1];
            left.CopyTo(z, 0);
            z[left.Length] = start.Value;
            right.CopyTo(z, left.Length + 1);
            return z;
        }

        private int[] PostOrderTraversalFromNode(Node start)
        {
            int[] left = { };
            int[] right = { };
            if (start.LeftChild != null) left = PostOrderTraversalFromNode(start.LeftChild);
            if (start.RightChild != null) right = PostOrderTraversalFromNode(start.RightChild);

            var z = new int[left.Length + right.Length + 1];
            left.CopyTo(z, 0);
            right.CopyTo(z, left.Length);
            z[left.Length + right.Length] = start.Value;
            return z;
        }

        private int[] LevelOrderTraversalFromNodeByDepth(Node start, int depth)
        {
            if (depth > 0)
            {
                int[] left = { };
                int[] right = { };
                if (start.LeftChild != null) left = LevelOrderTraversalFromNodeByDepth(start.LeftChild, depth - 1);
                if (start.RightChild != null) right = LevelOrderTraversalFromNodeByDepth(start.RightChild, depth - 1);

                return left.Union(right).ToArray();
            }

            return new[] {start.Value};
        }
    }
}