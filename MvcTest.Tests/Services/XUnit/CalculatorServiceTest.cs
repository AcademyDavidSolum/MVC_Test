using System;
using MvcTestServices.Interfaces;
using MvcTestServices.Services;
using Xunit;

namespace MvcTest.Tests.Services.XUnit
{
    public class CalculatorServiceTest
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Test the CalculatorService Add method
        /// </summary>
        [Fact]
        public void Add()
        {
            // Arrange
            ICalculatorService service = new CalculatorService();
            var first = (decimal)_random.NextDouble();
            var second = (decimal)_random.NextDouble();

            // Act
            var result = service.Add(first, second);

            // Assert
            Assert.Equal(first+second, result);
        }

        /// <summary>
        /// Test the CalculatorService Subtract method
        /// </summary>
        [Fact]
        public void Subtract()
        {
            // Arrange
            ICalculatorService service = new CalculatorService();
            var first = (decimal)_random.NextDouble();
            var second = (decimal)_random.NextDouble();

            // Act
            var result = service.Subtract(first, second);

            // Assert
            Assert.Equal(first-second, result);
        }

        /// <summary>
        /// Test the CalculatorService Multiply method
        /// </summary>
        [Fact]
        public void Multiply()
        {
            // Arrange
            ICalculatorService service = new CalculatorService();
            var first = (decimal)_random.NextDouble();
            var second = (decimal)_random.NextDouble();

            // Act
            var result = service.Multiply(first, second);

            // Assert
            Assert.Equal(first*second, result);
        }

        /// <summary>
        /// Test the CalculatorService Divide method
        /// </summary>
        [Fact]
        public void Divide()
        {
            // Arrange
            ICalculatorService service = new CalculatorService();
            var first = (decimal)_random.NextDouble();
            var second = (decimal)_random.NextDouble();

            // Act
            var result = service.Divide(first, second);

            // Assert
            Assert.Equal(first/second, result);
        }

        /// <summary>
        /// Test the CalculatorService Divide method, throwing ArgumentException
        /// </summary>
        [Fact]
        public void DivideWithZeroDivisorThrowsArgumentException()
        {
            // Arrange
            ICalculatorService service = new CalculatorService();
            var first = (decimal)_random.NextDouble();
            var second = 0M; // This will cause ArgumentException

            // Act / Assert
            Exception ex = Assert.Throws<ArgumentException>(() => service.Divide(first, second));
            Assert.Equal("Divisor cannot be 0.\r\nParameter name: divisor", ex.Message);
        }
    }
}
