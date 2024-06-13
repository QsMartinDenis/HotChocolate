using HotChocolate.Data.Filters;

namespace WebApplication1.CustomFilter
{
    public class RegexFilterOperation : FilterOperationConventionDescriptor
    {
        public RegexFilterOperation(int operationId) : base(500)
        {

        }
    }
}
