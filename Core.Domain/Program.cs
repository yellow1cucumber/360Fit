using API.Gate.GraphQl;
using API.Gate.GraphQl.Exceptions;
using API.Gate.GraphQl.Mutations;
using API.Gate.GraphQl.Subscriptions;
using DAL;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod())
);

builder.Services.AddDbContext<Context>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"),
                                 opt => opt.MigrationsAssembly("API.Gate")));

builder.Services.AddGraphQLServer()
                .RegisterDbContext<Context>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddErrorFilter<ErrorFilter>()

                .AddQueryType(q => q.Name("Query"))
                    .AddType<UsersQuery>()
                    .AddType<SellsQuery>()
                    .AddType<ServicesQuery>()
                    .AddType<ProductsQuery>()

                .AddMutationType(m => m.Name("Mutations"))
                    .AddType<UsersMutation>()
                    .AddType<ProductsMutations>()
                    .AddType<SellsMutation>()
                    .AddType<UsersMutation>()

                .AddRedisSubscriptions((sp) => ConnectionMultiplexer.Connect("127.0.0.1:6379"))
                .AddSubscriptionType(s => s.Name("Subscriptions"))
                    .AddType<ProductsSubscription>()
                    .AddType<SellsSubscription>()
                    .AddType<ServiceSubscription>()
                    .AddType<UsersSubscription>();
#endregion


var app = builder.Build();

#region MiddleWare
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseWebSockets();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
#endregion

app.Run();
