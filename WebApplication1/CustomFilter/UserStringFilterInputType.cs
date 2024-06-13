using HotChocolate.Data.Filters;
using WebApplication1.Documents;
using WebApplication1.HotChocoFilter;

namespace WebApplication1.CustomFilter
{
    public class UserStringFilterInputType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Name).Name("custom_name").Type<StringOperationFilterInputType>();
        }
    }
}
