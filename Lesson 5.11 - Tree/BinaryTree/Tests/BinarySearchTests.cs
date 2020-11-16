using System;
using Xunit;

namespace BinaryTree.Tests
{
    public class BinarySearchTests
    {
        private BinarySearchTree _binaryTree;
        private Random _random;

        public BinarySearchTests()
        {
            _binaryTree = new BinarySearchTree();
            _random = new Random();
        }

        [Fact]
        public void InsertTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8))};
            var exp = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            start.Insert(6);
            Assert.True(Node.CompareNodes(start.Root, exp.Root));
        }

        [Fact]
        public void DeleteTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            var exp = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8))};
            start.Delete(6);
            Assert.True(Node.CompareNodes(start.Root, exp.Root));
        }

        [Fact]
        public void SearchTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            Assert.True(start.Search(2) && !start.Search(9));
        }


        [Fact]
        public void SubtreeMinTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            Assert.Equal(2, start.SubtreeMin(start.Root));
        }

        [Fact]
        public void PreOrderTraversalTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            var exp = new[] {5, 2, 8, 6};
            Assert.Equal(exp, start.PreOrderTraversal());
        }


        [Fact]
        public void InOrderTraversalTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            var exp = new[] {2, 5, 6, 8};
            Assert.Equal(exp, start.InOrderTraversal());
        }

        [Fact]
        public void PostOrderTraversalTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            var exp = new[] {2, 6, 8, 5};
            Assert.Equal(exp, start.PostOrderTraversal());
        }

        [Fact]
        public void LevelOrderTraversalTest()
        {
            var start = new BinarySearchTree {Root = new Node(5, new Node(2), new Node(8, new Node(6)))};
            var exp = new[] {5, 2, 8, 6};
            Assert.Equal(exp, start.LevelOrderTraversal());
        }
    }
}