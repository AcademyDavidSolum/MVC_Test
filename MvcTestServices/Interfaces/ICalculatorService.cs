namespace MvcTestServices.Interfaces
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Add two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical sum of the two values</returns>
        decimal Add(decimal first, decimal second);
        /// <summary>
        /// Subtract two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical difference of the two values</returns>
        decimal Subtract(decimal first, decimal second);
        /// <summary>
        /// Multiply two decimal values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>The mathematical product of the two values</returns>
        decimal Multiply(decimal first, decimal second);
        /// <summary>
        /// Divide two decimal values
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns>the mathematical quotient of the two values</returns>
        decimal Divide(decimal dividend, decimal divisor);
    }
}
