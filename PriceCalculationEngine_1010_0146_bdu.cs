// 代码生成时间: 2025-10-10 01:46:32
 * The engine is designed to be extensible and maintainable,
 * allowing for the addition of new rules or changes to existing ones.
# NOTE: 重要实现细节
 */
using System;

namespace PriceCalculationEngine
{
    // Exception for price calculation errors
    public class PriceCalculationException : Exception
    {
        public PriceCalculationException(string message) : base(message)
        {
        }
    }

    // Base interface for price calculation rules
    public interface IPriceCalculationRule
# NOTE: 重要实现细节
    {
        decimal ApplyRule(decimal price);
    }

    // Concrete implementation of a discount rule
    public class DiscountRule : IPriceCalculationRule
    {
        private readonly decimal discountPercentage;

        public DiscountRule(decimal discountPercentage)
        {
            this.discountPercentage = discountPercentage;
        }

        public decimal ApplyRule(decimal price)
        {
            if (price < 0)
                throw new PriceCalculationException("Price cannot be negative.");
            return price * (1 - discountPercentage / 100);
        }
    }

    // Concrete implementation of a tax rule
    public class TaxRule : IPriceCalculationRule
    {
        private readonly decimal taxPercentage;

        public TaxRule(decimal taxPercentage)
# 扩展功能模块
        {
            this.taxPercentage = taxPercentage;
        }

        public decimal ApplyRule(decimal price)
        {
            if (price < 0)
                throw new PriceCalculationException("Price cannot be negative.");
            return price * (1 + taxPercentage / 100);
        }
    }

    // Price calculation engine
    public class PriceCalculationEngine
    {
        private readonly IPriceCalculationRule[] rules;

        public PriceCalculationEngine(params IPriceCalculationRule[] rules)
        {
            this.rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        public decimal CalculatePrice(decimal initialPrice)
        {
            if (initialPrice < 0)
                throw new PriceCalculationException("Initial price cannot be negative.");

            decimal price = initialPrice;

            foreach (var rule in rules)
            {
                price = rule.ApplyRule(price);
            }

            return price;
        }
    }

    // Example usage
    class Program
    {
        static void Main(string[] args)
        {
# 添加错误处理
            try
            {
                var engine = new PriceCalculationEngine(
                    new DiscountRule(10), // 10% discount
# 改进用户体验
                    new TaxRule(15) // 15% tax
                );

                var finalPrice = engine.CalculatePrice(100m); // Initial price is $100
                Console.WriteLine("The final price is: \${0:0.00}", finalPrice);
            }
            catch (PriceCalculationException ex)
            {
                Console.WriteLine("Error calculating price: " + ex.Message);
            }
        }
    }
}