// 代码生成时间: 2025-09-18 03:22:24
using System;

namespace MathToolsApp
{
    public class MathematicsTools
    {
        // Adds two numbers together.
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtracts the second number from the first.
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplies two numbers.
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divides the first number by the second.
# 扩展功能模块
        // Throws an exception if the denominator is zero.
# 增强安全性
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
# NOTE: 重要实现细节
            }
            return a / b;
# FIXME: 处理边界情况
        }

        // Calculates the square root of a number.
# TODO: 优化性能
        // Throws an exception if the number is negative.
        public double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Cannot calculate the square root of a negative number.");
# 增强安全性
            }
            return Math.Sqrt(number);
        }
# TODO: 优化性能

        // Calculates the factorial of a non-negative integer.
        // Throws an exception if the number is negative.
        public long Factorial(int number)
# TODO: 优化性能
        {
            if (number < 0)
# NOTE: 重要实现细节
            {
                throw new ArgumentOutOfRangeException("number", "Cannot calculate factorial of a negative number.");
            }

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
# FIXME: 处理边界情况
            }
            return result;
        }
    }
}
