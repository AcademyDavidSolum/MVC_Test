using System;
using MvcTestServices.Interfaces;

namespace MvcTestServices.Services
{
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// Add two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical sum of the two values</returns>
        public decimal Add(decimal first, decimal second)
        {
            return first + second;
        }

        /// <summary>
        /// Subtract two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical difference of the two values</returns>
        public decimal Subtract(decimal first, decimal second)
        {
            return first - second;
        }

        /// <summary>
        /// Multiply two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical product of the two values</returns>
        public decimal Multiply(decimal first, decimal second)
        {
            return first * second;
        }

        /// <summary>
        /// Divide two decimal values
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns>the mathematical quotient of the two values</returns>
        public decimal Divide(decimal dividend, decimal divisor)
        {
            if (divisor == 0)
            {
                throw new ArgumentException("Divisor cannot be 0.", nameof(divisor));
            }
            return dividend / divisor;
        }
    }
}
