using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using System.Linq.Expressions;
using System.Reflection;
using WebApplication1.HotChocoFilter;

namespace WebApplication1.CustomFilter
{
    public class RegexFilterOperationHandler : QueryableStringOperationHandler
    {
        public RegexFilterOperationHandler(InputParser inputParser) : base(inputParser)
        {
        }

        protected override int Operation => CustomOperations.regex;

        public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, IValueNode node, object parsedValue)
        {
            // Get the instance of the context (usually the entity or string being queried)
            Expression inputExpression = context.GetInstance();

            if (node is StringValueNode stringValueNode)
            {
                // The pattern to match (already transformed to lowercase)
                var pattern = stringValueNode.Value.ToLower();

                // Create a constant expression for the pattern (already transformed to lowercase)
                ConstantExpression patternExpression = Expression.Constant(pattern, typeof(string));

                // Call ToLower() on inputExpression
                MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", new Type[] { });
                MethodCallExpression toLowerCall = Expression.Call(inputExpression, toLowerMethod);

                // Call Contains() on toLowerCall with patternExpression as argument
                MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                MethodCallExpression containsCall = Expression.Call(toLowerCall, containsMethod, patternExpression);

                return containsCall;
            }

            throw new InvalidOperationException("Invalid regex filter operation");
        }



        /*public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, IValueNode node, object parsedValue)
        {
            // Get the instance of the context (usually the entity or string being queried)
            Expression inputExpression = context.GetInstance();

            if (node is StringValueNode stringValueNode)
            {
                // The pattern to match
                var pattern = stringValueNode.Value;

                // Create a constant expression for the pattern
                ConstantExpression patternExpression = Expression.Constant(pattern, typeof(string));

                // Get Regex.Matches method info
                MethodInfo regexMatchesMethod = typeof(Regex).GetMethod("Matches", new Type[] { typeof(string), typeof(string) });

                // Create a method call expression for Regex.Matches(inputExpression, pattern)
                MethodCallExpression regexMatchesCall = Expression.Call(null, regexMatchesMethod, inputExpression, patternExpression);

                return regexMatchesCall; // Return MatchCollection directly
            }

            throw new InvalidOperationException("Invalid regex filter operation");
        }*/
    }
}
