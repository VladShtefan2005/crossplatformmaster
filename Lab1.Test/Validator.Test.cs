namespace Lab1.Test
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("10 1 2 100", true, 10, 1, 2, 100)]
        [InlineData("1 0 0 2", true, 1, 0, 0, 2)]
        public void ValidateInput_ValidInput_ReturnsTrue(string input, bool expectedResult, int expectedN, int expectedK1, int expectedK2, long expectedS)
        {

            bool result = Validator.ValidateInput(input, out int N, out int K1, out int K2, out long S);

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedN, N);
            Assert.Equal(expectedK1, K1);
            Assert.Equal(expectedK2, K2);
            Assert.Equal(expectedS, S);
        }

        [Theory]
        [InlineData("10 1 2", false)] 
        [InlineData("10 1 2 100 a", false)] 
        [InlineData("0 1 2 100", false)] 
        [InlineData("10 -1 2 100", false)] 
        [InlineData("10 1 10 100", false)] 
        [InlineData("10 1 2 1", false)] 
        public void ValidateInput_InvalidInput_ReturnsFalse(string input, bool expectedResult)
        {
            bool result = Validator.ValidateInput(input, out int N, out int K1, out int K2, out long S);
            Assert.Equal(expectedResult, result);
        }
    }
}