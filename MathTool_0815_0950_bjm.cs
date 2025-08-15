// 代码生成时间: 2025-08-15 09:50:22
using System;

namespace MathToolMAUI
{
    /// <summary>
    /// Math tool set providing basic operations.
    /// </summary>
    public class MathTool
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second number from the first.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides the first number by the second.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the divisor is zero.</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
    }
}
