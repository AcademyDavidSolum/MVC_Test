using System.Threading.Tasks;

namespace MvcTestServices.Interfaces
{
    public interface IUnaware
    {
        /// <summary>
        /// Send an email synchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>Success or failure</returns>
        bool Send(string from, string to, string subject, string body);
        /// <summary>
        /// Send an email asynchronously
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>A Task whose Result represents success or failure</returns>
        Task<bool> SendAsync(string from, string to, string subject, string body);
    }
}
