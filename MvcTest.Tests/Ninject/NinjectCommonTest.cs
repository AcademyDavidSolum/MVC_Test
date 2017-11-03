using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTestServices.Interfaces;
using MvcTestServices.Services;
using MvcTestServices.Services.Ninject;
using Ninject;

namespace MvcTest.Tests.Ninject
{
    [TestClass]
    public class NinjectCommonTest
    {
        /// <summary>
        /// Test that an injected ICalculatorService is an instance of CalculatorService
        /// </summary>
        [TestMethod]
        public void InjectionTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator = kernel.Get<ICalculatorService>();

                // Assert
                Assert.IsInstanceOfType(calculator, typeof(CalculatorService));
            }
        }

        /// <summary>
        /// Test that two singleton calculators are the same
        /// -- singleton calculator are obtained via the name, "SingletonCalculator"
        /// </summary>
        [TestMethod]
        public void SingletonTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator1 = kernel.Get<ICalculatorService>("SingletonCalculator");
                var calculator2 = kernel.Get<ICalculatorService>("SingletonCalculator");

                // Assert
                Assert.AreEqual(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that two transient calculators are not the same
        /// -- transient is the default
        /// </summary>
        [TestMethod]
        public void TransientTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator1 = kernel.Get<ICalculatorService>();
                var calculator2 = kernel.Get<ICalculatorService>();

                // Assert
                Assert.AreNotEqual(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that a singleton calculator is not the same as a transient
        /// -- singleton calculator are obtained via the name, "SingletonCalculator"
        /// -- transient is the default
        /// </summary>
        [TestMethod]
        public void SingletonVsTransientTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act
                var calculator1 = kernel.Get<ICalculatorService>("SingletonCalculator");
                var calculator2 = kernel.Get<ICalculatorService>();

                // Assert
                Assert.AreNotEqual(calculator1, calculator2);
            }
        }

        /// <summary>
        /// Test that requesting a type of which the container is unaware throws an Exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void UnregisteredTypeTest()
        {
            // Arrange
            using (var kernel = NinjectCommon.CreateKernel())
            {
                // Act / Assert -- this should throw the expected exception
                kernel.Get<IUnaware>();
            }
        }
    }
}
