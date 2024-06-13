using HotChocolate.Data.Filters;

namespace WebApplication1.CustomFilter
{
    public class CustomStringOperationFilterInputType : StringOperationFilterInputType
    {
        protected override void Configure(IFilterInputTypeDescriptor descriptor)
        {
            descriptor.Operation(500).Type<StringType>();
            descriptor.Operation(DefaultFilterOperations.NotEquals).Type<StringType>();
        }
    }
}
