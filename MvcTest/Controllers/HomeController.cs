using System.Web.Mvc;
using MvcTestServices.Interfaces;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly IEmailService _emailService;
        public HomeController(
            /*[Named("SingletonCalculator")]*/ ICalculatorService calculatorService, 
            IEmailService emailService)
        {
            _calculatorService = calculatorService;
            _emailService = emailService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = $"David Solum's MVC Test: 4 + 6 = {_calculatorService.Add(4, 6)}";

            // Let's email this important calculation to Dave
            // (Note: this currently throws a NotImplementedException)
            //_emailService.Send("dave@davidsolum.com", "dave@davidsolum.com", "Calculation", ViewBag.Message);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "David Solum";

            return View();
        }
    }
}