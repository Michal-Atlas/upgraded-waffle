using Xunit;

namespace BinaryTree.Tests
{
    public class NodeTests
    {
        [Fact]
        public void ComparePositiveTest()
        {
            var x = new Node(0, new Node(5), new Node(4, new Node(3)));
            var y = new Node(0, new Node(5), new Node(4, new Node(3)));
            Assert.True(Node.CompareNodes(x, y));
        }

        [Fact]
        public void CompareNegativeTest()
        {
            var x = new Node(0, new Node(5), new Node(4));
            var y = new Node(0, new Node(5), new Node(4, new Node(3)));
            Assert.False(Node.CompareNodes(x, y));
        }
    }
}