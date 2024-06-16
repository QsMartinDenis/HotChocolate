using HotChocolate.Data.Filters;
using HotChocolate.Data.MongoDb.Filters;
using HotChocolate.Data.MongoDb;
using HotChocolate.Language;
using MongoDB.Bson;
using System.Text.RegularExpressions;
using WebApplication1.HotChocoFilter;

namespace WebApplication1.CutomFilterMongo;

public class RegexFilterOperationHandlerMongo : MongoDbStringOperationHandler /*MongoDbStringContainsHandler*/
{
    public RegexFilterOperationHandlerMongo(InputParser inputParser) : base(inputParser)
    {
    }

    protected override int Operation => CustomOperations.regex;

    public override MongoDbFilterDefinition HandleOperation(
        MongoDbFilterVisitorContext context, 
        IFilterOperationField field, 
        IValueNode value, 
        object? parsedValue)
    {
        if (parsedValue is string str)
        {
            // Construct a MongoDB filter for substring match using $regex
            var regexDoc = new MongoDbFilterOperation(
                "$regex",
                new BsonRegularExpression(Regex.Escape(str), "i")); // "i" for case insensitivity //new BsonRegularExpression($".*{escapedStr}.*", "i"));

            // Construct the final filter definition for MongoDB
            var path = context.GetMongoFilterScope().GetPath(); // Assuming this gets the correct path in MongoDB
            var filterDoc = new MongoDbFilterOperation(path, regexDoc);

            return filterDoc;
        }

        throw new InvalidOperationException("Invalid regex filter operation");
    }
}
