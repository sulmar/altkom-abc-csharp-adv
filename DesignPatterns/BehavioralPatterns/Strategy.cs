using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralPatterns
{
    class Strategy
    {
        public static void Test()
        {
            Test1();

        }

        private static void Test1()
        {
            IDiscountStrategy discountStrategy =
                            new HappyHoursPercentageDiscountStrategy(
                                TimeSpan.Parse("09:30"),
                                TimeSpan.Parse("16:00"),
                                0.1m);

            OrderCalculator orderCalculator
                = new OrderCalculator(discountStrategy);

            Order order = new Order(500, new Customer("Marcin"));

            decimal discount = orderCalculator.CalculateDiscount(order);

            Console.WriteLine($"discount: {discount}");
        }

        private static void Test2()
        {
            ICanDiscountStrategy canDiscountStrategy =
                            new HappyHoursCanDiscountStrategy(
                                TimeSpan.Parse("09:30"),
                                TimeSpan.Parse("16:00"));

            IGetDiscountStrategy getDiscountStrategy = new FixedGetDiscountStrategy(20m);

            OrderCalculator2 orderCalculator
                = new OrderCalculator2(canDiscountStrategy, getDiscountStrategy);

            Order order = new Order(500, new Customer("Marcin"));

            decimal discount = orderCalculator.CalculateDiscount(order);

            Console.WriteLine($"discount: {discount}");
        }
    }

    
    public class OrderCalculator
    {
        private readonly IDiscountStrategy discountStrategy;

        public OrderCalculator(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (discountStrategy.CanDiscount(order))
                return discountStrategy.GetDiscount(order);
            else
                return 0;
        }
    }

    public class OrderCalculator2
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly IGetDiscountStrategy getDiscountStrategy;

        public OrderCalculator2(
            ICanDiscountStrategy canDiscountStrategy, 
            IGetDiscountStrategy getDiscountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy;
            this.getDiscountStrategy = getDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))
                return getDiscountStrategy.GetDiscount(order);
            else
                return 0;
        }
    }

    public class HappyHoursCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order) => 
            order.OrderDate.TimeOfDay >= from
            && order.OrderDate.TimeOfDay <= to;
    }

    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly Gender gender;

        public GenderCanDiscountStrategy(Gender gender) => this.gender = gender;

        public bool CanDiscount(Order order) => order.Customer.Gender == gender;
    }

    public class PercentageGetDiscountStrategy : IGetDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageGetDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal GetDiscount(Order order) => order.TotalAmount * percentage;
    }



    public class FixedGetDiscountStrategy : IGetDiscountStrategy
    {
        private readonly decimal amount;

        public FixedGetDiscountStrategy(decimal amount) => this.amount = amount;

        public decimal GetDiscount(Order order) => amount;
    }

    public interface IDiscountStrategy
    {
        bool CanDiscount(Order order);
        decimal GetDiscount(Order order);
    }

    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

    public interface IGetDiscountStrategy
    {
        decimal GetDiscount(Order order);
    }

  

    public class HappyHoursPercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal percentage;

        public HappyHoursPercentageDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                  && order.OrderDate.TimeOfDay <= to;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    public class HappyHoursFixedDiscountStrategy : IDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal amount;

        public HappyHoursFixedDiscountStrategy(TimeSpan from, TimeSpan to, decimal amount)
        {
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                  && order.OrderDate.TimeOfDay <= to;
        }

        public decimal GetDiscount(Order order)
        {
            return amount;
        }
    }
}
