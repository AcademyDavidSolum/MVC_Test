using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTest.Controllers;
using MvcTestServices.Interfaces;

namespace MvcTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly Mock<ICalculatorService> _calculatorServiceMoq = new Mock<ICalculatorService>();
        private readonly Mock<IEmailService> _emailServiceMoq = new Mock<IEmailService>();

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_calculatorServiceMoq.Object, _emailServiceMoq.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_calculatorServiceMoq.Object, _emailServiceMoq.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result?.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_calculatorServiceMoq.Object, _emailServiceMoq.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
