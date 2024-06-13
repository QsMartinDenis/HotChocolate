using HotChocolate.Data.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication1.CustomFilter;
using WebApplication1.Mongo;
using WebApplication1.Queries;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering<CustomFilterConvention>()
                .AddType<UserStringFilterInputType>()
                .AddProjections();

builder.Services.Configure<MongoDBSettings>(
        builder.Configuration.GetSection(nameof(MongoDBSettings)));

builder.Services.AddSingleton<IMongoDBSettings>(sp =>
        sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddSingleton<RegexFilterOperationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGraphQL();
app.MapControllers();

app.Run();
