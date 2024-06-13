using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using Microsoft.OpenApi.Extensions;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace WebApplication1.CustomFilter
{
    public class RegexFilterOperationHandler : QueryableStringOperationHandler
    {
        public RegexFilterOperationHandler(InputParser inputParser) : base(inputParser)
        {
        }

        protected override int Operation => 500;

        public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, IValueNode node, object parsedValue)
        {
            if (node is StringValueNode stringValueNode)
            {
                var pattern = stringValueNode.Value;
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var TypeName = context.GetInstance().Type.Name;
                var FullName = context.GetInstance().Type.FullName;
                var NodeType = context.GetInstance().NodeType.GetDisplayName();

                var parameter = Expression.Parameter(context.GetType(), "e");
                var property = Expression.Property(parameter, field.Member.Name);
                var regexMatchMethod = typeof(Regex).GetMethod(nameof(Regex.IsMatch), new[] { typeof(string) });
                var regexInstance = Expression.Constant(regex);
                var regexCall = Expression.Call(regexInstance, regexMatchMethod, property);

                return Expression.Lambda(regexCall, parameter);
            }

            throw new InvalidOperationException("Invalid regex filter operation");
        }
    }
}
