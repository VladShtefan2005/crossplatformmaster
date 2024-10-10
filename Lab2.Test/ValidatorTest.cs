namespace Lab2.Test
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(32)]
        public void IsValid_ValidInputs_ReturnsTrue(int n)
        {
            bool result = Validator.IsValid(n);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(33)]
        [InlineData(-1)]
        public void IsValid_InvalidInputs_ReturnsFalse(int n)
        {
            bool result = Validator.IsValid(n);
            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(32)]
        public void IsEven_ValidEvenInputs_ReturnsTrue(int n)
        {
            bool result = Validator.IsEven(n);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsEven_InvalidOddInputs_ReturnsFalse(int n)
        {
            bool result = Validator.IsEven(n);
            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(32)]
        public void Validate_ValidInput_DoesNotThrow(int n)
        {
            var exception = Record.Exception(() => Validator.Validate(n));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(33)]
        [InlineData(3)]
        public void Validate_InvalidInput_ThrowsArgumentException(int n)
        {
            Assert.Throws<ArgumentException>(() => Validator.Validate(n));
        }
    }
}
