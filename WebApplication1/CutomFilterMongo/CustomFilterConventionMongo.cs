using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;
using WebApplication1.HotChocoFilter;

namespace WebApplication1.CutomFilterMongo
{
    public class CustomFilterConventionMongo : FilterConvention
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddMongoDbDefaults();

            descriptor.Operation(CustomOperations.regex).Name("regex");

            descriptor.Configure<StringOperationFilterInputType>(x => x.Operation(CustomOperations.regex)
                                                                       .Type<StringType>());

            descriptor.Provider(new MongoDbFilterProvider(x => x.AddDefaultMongoDbFieldHandlers()
                                                                .AddFieldHandler<RegexFilterOperationHandlerMongo>()));
        }
    }
}
