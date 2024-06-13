using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using WebApplication1.HotChocoFilter;

namespace WebApplication1.CustomFilter
{
    public class CustomFilterConvention : FilterConvention
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddDefaults();
            descriptor.Operation(500).Name("regex");
            
            descriptor.AddProviderExtension(
                new QueryableFilterProviderExtension(
                    x => x.AddFieldHandler<RegexFilterOperationHandler>()));
            descriptor.AddDefaultOperations();
        }
    }
}
