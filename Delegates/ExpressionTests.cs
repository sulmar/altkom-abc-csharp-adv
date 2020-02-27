using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Delegates
{
    class ExpressionTests
    {
        static Expression<Func<int, bool>> expression = number => number < 5;

        // https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/concepts/expression-trees/
        public static void Test()
        {
            Console.WriteLine(expression.Body);
        }
    }
}
