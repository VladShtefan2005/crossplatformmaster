namespace Lab3.Test
{
    public class NegativeCycleDetectorTests
    {
        [Fact]
        public void TestHasNegativeCycle_SingleVertex_NoEdges_ReturnsFalse()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0 } 
            };
            bool result = detector.HasNegativeCycle(graph, 1);
            Assert.False(result);
        }

        [Fact]
        public void TestHasNegativeCycle_SingleVertex_WithSelfLoop_ReturnsFalse()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0 } 
            };
            bool result = detector.HasNegativeCycle(graph, 1);
            Assert.False(result);
        }

        [Fact]
        public void TestHasNegativeCycle_TwoVertices_PositiveEdge_ReturnsFalse()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 1 },
            { 1, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 2);
            Assert.False(result);
        }

        [Fact]
        public void TestHasNegativeCycle_TwoVertices_NegativeCycle_ReturnsTrue()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, -1 },
            { -1, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 2);
            Assert.True(result);
        }

        [Fact]
        public void TestHasNegativeCycle_LargeGraph_NoNegativeCycle_ReturnsFalse()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 1, 2, 3, 4 },
            { 1, 0, 5, 6, 7 },
            { 2, 5, 0, 8, 9 },
            { 3, 6, 8, 0, 10 },
            { 4, 7, 9, 10, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 5);
            Assert.False(result);
        }

        [Fact]
        public void TestHasNegativeCycle_LargeGraph_WithNegativeCycle_ReturnsTrue()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 1, 2, -5 },
            { 1, 0, -3, 4 },
            { 2, -3, 0, 5 },
            { -5, 4, 5, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 4);
            Assert.True(result);
        }

        [Fact]
        public void TestHasNegativeCycle_DenseGraph_WithMultipleNegativeCycles_ReturnsTrue()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, -1, -2, 0 },
            { -1, 0, -3, 0 },
            { -2, -3, 0, -4 },
            { 0, 0, -4, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 4);
            Assert.True(result);
        }

        [Fact]
        public void TestHasNegativeCycle_ThreeVertices_NegativeCycleViaThirdVertex_ReturnsTrue()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 2, -5 },
            { 2, 0, 3 },
            { -5, 3, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 3);
            Assert.True(result);
        }

        [Fact]
        public void TestHasNegativeCycle_ThreeVertices_NoNegativeCycle_ReturnsFalse()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 1, 2 },
            { 1, 0, 1 },
            { 2, 1, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 3);
            Assert.False(result);
        }

        [Fact]
        public void TestHasNegativeCycle_LargeGraph_WithNegativeCycleAtEnd_ReturnsTrue()
        {
            var detector = new NegativeCycleDetector();
            int[,] graph = new int[,]
            {
            { 0, 2, 3, 4, 5 },
            { 2, 0, 1, 2, 3 },
            { 3, 1, 0, 2, -6 }, 
            { 4, 2, 2, 0, 1 },
            { 5, 3, -6, 1, 0 }
            };
            bool result = detector.HasNegativeCycle(graph, 5);
            Assert.True(result);
        }
    }
}