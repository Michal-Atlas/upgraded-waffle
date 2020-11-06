namespace BinaryTree
{
    public class Node
    {
        public int Value;

        public Node(int value, Node leftChild = null, Node rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public override string ToString()
        {
            return Value + "{" + (LeftChild != null ? LeftChild.ToString() : "-") +
                   (RightChild != null ? RightChild.ToString() : "-") + "}";
        }
    }
}