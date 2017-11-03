using System;
using MvcTestServices.Interfaces;
using MvcTestServices.Services;
using MvcTestServices.Services.Ninject;
using Ninject;
using Xunit;

namespace MvcTest.Tests.XUnit.Ninject
{
    public class NinjectCommonTest
    {
        /// <summary>
        /// Test that an injected ICalculatorService is an instance of CalculatorService
        /// </summary>
        [Fact]
        public void InjectionTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator = kernel.Get<ICalculatorService>();

                // Assert
                Assert.IsType<CalculatorService>(calculator);
            }
        }

        /// <summary>
        /// Test that two singleton calculators are the same
        /// -- singleton calculator are obtained via the name, "SingletonCalculator"
        /// </summary>
        [Fact]
        public void SingletonTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator1 = kernel.Get<ICalculatorService>("SingletonCalculator");
                var calculator2 = kernel.Get<ICalculatorService>("SingletonCalculator");

                // Assert
                Assert.Equal(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that two transient calculators are not the same
        /// -- transient is the default
        /// </summary>
        [Fact]
        public void TransientTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                var calculator1 = kernel.Get<ICalculatorService>();
                var calculator2 = kernel.Get<ICalculatorService>();

                // Assert
                Assert.NotEqual(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that a singleton calculator is not the same as a transient
        /// -- singleton calculator are obtained via the name, "SingletonCalculator"
        /// -- transient is the default
        /// </summary>
        [Fact]
        public void SingletonVsTransientTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                var calculator1 = kernel.Get<ICalculatorService>("SingletonCalculator");
                var calculator2 = kernel.Get<ICalculatorService>();

                // Assert
                Assert.NotEqual(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that requesting a type of which the container is unaware throws an Exception
        /// </summary>
        [Fact]
        public void UnregisteredTypeTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act / Assert -- this should throw the expected exception
                Exception ex = Assert.Throws<ActivationException>(() => kernel.Get<IUnaware>());
                Assert.StartsWith("Error activating IUnaware\r\nNo matching bindings are available, and the type is not self-bindable.", ex.Message);
            }
        }
    }
}
