namespace Lab2.Test
{
    public class LogicTests
    {
        [Theory]
        [InlineData(2, 3)] 
        [InlineData(4, 11)] 
        [InlineData(6, 41)] 
        [InlineData(8, 153)] 
        public void CalculateWays_ValidInputs_ReturnsExpected(int n, int expected)
        {
            int result = Logic.CalculateWays(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void CalculateWays_OddInput_ReturnsZero(int n)
        {
            int result = Logic.CalculateWays(n);
            Assert.Equal(0, result);
        }
    }
}
