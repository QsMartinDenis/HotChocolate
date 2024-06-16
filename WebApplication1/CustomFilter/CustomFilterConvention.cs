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
            descriptor.AddDefaultOperations();

            descriptor.Operation(CustomOperations.regex).Name("regex");

            descriptor.Configure<StringOperationFilterInputType>(x => x.Operation(CustomOperations.regex)
                                                                       .Type<StringType>());

            descriptor.Provider(new QueryableFilterProvider(x => x.AddDefaultFieldHandlers()
                                                                  .AddFieldHandler<RegexFilterOperationHandler>()));

            /*string pattern = @"\d+";
            string input = "There are 123 numbers in this string.";

            bool hasMatch = Regex.Matches(input, pattern).Any();*/

            /*descriptor.AddProviderExtension(
                new QueryableFilterProviderExtension(x => x.AddFieldHandler<RegexFilterOperationHandler>()
                                                           .AddDefaultFieldHandlers()));*/
        }
    }
}
