using HotChocolate.Data.Filters;

namespace WebApplication1.HotChocoFilter;

public static class CustomerFilterConventionExtensions
{
    public static IFilterConventionDescriptor AddInvariantComparison(
        this IFilterConventionDescriptor conventionDescriptor) =>
        conventionDescriptor.Configure<StringOperationFilterInputType>(
        x => x.Operation(CustomOperations.regex));
}