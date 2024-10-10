namespace Lab1.Test
{
    public class LogicTest
    {
        [Theory]
        
        [InlineData("5 0 0 50", 25, 25)] 
        
        public void Process_ValidInput_CalculatesCorrectCoins(string input, long expectedPetyaCoins, long expectedVasyaCoins)
        {
            var result = Logic.Process(input);

            Assert.Equal(expectedPetyaCoins, result.petyaCoins);
            Assert.Equal(expectedVasyaCoins, result.vasyaCoins);
        }

        [Fact]
        public void Process_InvalidInput_ReturnsZero()
        {
            string input = "invalid input data"; 

            var result = Logic.Process(input);

            Assert.Equal(0, result.petyaCoins);
            Assert.Equal(0, result.vasyaCoins);
        }

        [Theory]
        [InlineData("10 -1 3 100", 0, 0)] 
        [InlineData("10 2 -1 100", 0, 0)] 
        [InlineData("10 11 3 100", 0, 0)] 
        [InlineData("10 2 11 100", 0, 0)] 
        [InlineData("10 2 3 -100", 0, 0)] 
        public void Process_InvalidValues_ReturnsZero(string input, long expectedPetyaCoins, long expectedVasyaCoins)
        {
            var result = Logic.Process(input);

            Assert.Equal(expectedPetyaCoins, result.petyaCoins);
            Assert.Equal(expectedVasyaCoins, result.vasyaCoins);
        }
    }
}
