using System.Linq;
using MvcTestServices.Interfaces;
using Ninject;
using Ninject.Modules;

namespace MvcTestServices.Services.Ninject
{
    public class NinjectCommon : NinjectModule
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterDependencies(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your dependencies here
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterDependencies(IKernel kernel)
        {
            kernel.Bind<ICalculatorService>().To<CalculatorService>()
                .InSingletonScope()
                .Named("SingletonCalculator");
            kernel.Bind<ICalculatorService>().To<CalculatorService>()
                .When(x => x.Parameters.FirstOrDefault()?.Name == null)
                .InTransientScope();
            kernel.Bind<IEmailService>().To<EmailService>().InTransientScope();
        }

        public override void Load()
        {
        }
    }
}