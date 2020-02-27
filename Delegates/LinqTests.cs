using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Delegates
{
    class Person
    {
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public Person(string firstName, Gender gender = Gender.Man)
        {
            FirstName = firstName;
            Gender = gender;
        }
    }

    enum Gender
    {
        Woman,
        Man
    }

    class LinqTests
    {

        public static void GroupByTest()
        {
            var persons = new List<Person>
            {
                new Person("Maciej"),
                new Person("Adrian"),
                new Person("Anna", Gender.Woman),
                new Person("Kamil"),
                new Person("Hanna", Gender.Woman)
            };

            var query = persons
                .GroupBy(p => p.Gender)
                .ToList();

            var query2 = persons
                .GroupBy(p => p.Gender)
                .Select(g => new { Gender = g.Key, Count = g.Count() })
                .ToList();
        }


        public static void Test()
        {
            GroupByTest();

            // SetsTest();
        }

        private static void SetsTest()
        {
            IEnumerable<int> happyNumbers = new List<int> { 4, 6, 78, 8 };
            IEnumerable<int> numbers = new List<int> { 3, 5, 6, 8 };

            var union = happyNumbers
                        .Union(numbers);

            var expect = happyNumbers
                .Except(numbers);

            var specialNumber = happyNumbers.Any(n => n == 6);

            if (numbers.Any())
            {

            }

            if (happyNumbers.All(n => n > 1))
            {

            }



            var mynumbers = happyNumbers
                .Where(n => n > 5)
                .OrderBy(n => n)
                .Select(n => n + 1)
                .ToList();

            var q = from n in happyNumbers
                    where n > 5
                    orderby n
                    select n + 1;

            var q2 = from n in happyNumbers
                     join m in numbers on n equals m
                     select new { n, m };

            foreach (var number in mynumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
