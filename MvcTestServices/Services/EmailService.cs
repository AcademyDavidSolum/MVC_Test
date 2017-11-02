using System.Threading.Tasks;
using MvcTestServices.Interfaces;

namespace MvcTestServices.Services
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Send an email synchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>Success or failure</returns>
        public bool Send(string from, string to, string subject, string body)
        {
            // TODO: Send email here
            return true;
        }

        /// <summary>
        /// Send an email asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>A Task whose Result represents success or failure</returns>
        public async Task<bool> SendAsync(string from, string to, string subject, string body)
        {
            // TODO: Send email asynchronously here
            return true;
        }
    }
}
