using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralPatterns
{
    class TemplateMethod
    {
        public static void Test()
        {
            Order order = new Order(500, new Customer("Marcin"));

            IOrderCalculator orderCalculator = new HappyHoursOrderCalculator(
                    from: TimeSpan.Parse("09:20"), 
                    to: TimeSpan.Parse("16:00"), 
                    0.1m);

            decimal discount = orderCalculator.CalculateDiscount(order);

            Console.WriteLine($"discount: {discount}");
        }

        //private static decimal CalculateDiscount(Order order)
        //{
        //    if (order.OrderDate.TimeOfDay >= TimeSpan.Parse("09:30")
        //        && order.OrderDate.TimeOfDay <= TimeSpan.Parse("16:59"))
        //        return order.TotalAmount * 0.1m;
        //    else
        //        return 0;
        //}
    }

    public interface IOrderCalculator 
    {
        decimal CalculateDiscount(Order order);
    }

    public class HappyHoursOrderCalculator2 : BaseOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal percentage;

        public HappyHoursOrderCalculator2(
            TimeSpan from,
            TimeSpan to,
            decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        protected override bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                  && order.OrderDate.TimeOfDay <= to;
        }

        protected override decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    public abstract class BaseOrderCalculator
    {
        protected abstract bool CanDiscount(Order order);
        protected abstract decimal GetDiscount(Order order);

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order))
                return GetDiscount(order);
            else
                return 0;
        }
    }

    public class HappyDayOrderCalculator : IOrderCalculator
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly decimal percentage;

        public HappyDayOrderCalculator(DayOfWeek dayOfWeek, decimal percentage)
        {
            this.dayOfWeek = dayOfWeek;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.OrderDate.DayOfWeek == dayOfWeek)
                return order.TotalAmount * percentage;
            else
                return 0;
        }
    }

    


    public class HappyHoursOrderCalculator : IOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal percentage;

        public HappyHoursOrderCalculator(
            TimeSpan from, 
            TimeSpan to, 
            decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (order.OrderDate.TimeOfDay >= from
                  && order.OrderDate.TimeOfDay <= to)
                return order.TotalAmount * percentage;
            else
                return 0;
        }
    }


    public class Order
    {
        public Order(decimal totalAmount, Customer customer)
        {
            OrderDate = DateTime.Now;
            TotalAmount = totalAmount;
            Customer = customer;
        }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public Customer(string firstName, Gender gender = Gender.Man)
        {
            FirstName = firstName;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    { 
        Woman,
        Man
    }

}
