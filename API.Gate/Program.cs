using DAL;
using Infrastructure.DTO.Profiles;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Keycloak.AuthServices.Authentication;
using System.Net;
using Infrastructure.GraphQL;
using Infrastructure.GraphQL.Redis;
using API.Gate.Configuration;


var builder = WebApplication.CreateBuilder(args);

#region HTTPS
builder.WebHost.UseSetting("DOTNET_USE_DEV_CERTIFICATE", "false");
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 7070);
    options.Listen(IPAddress.Any, 7071, listenOptions =>
    {
        listenOptions.UseHttps("/https/certs/360Fit-API-pfx-dev.pfx", "Tiberium13");
    });
});
#endregion


#region Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(
    typeof(UsersProfile),
    typeof(SellsProfile),
    typeof(OrganizationProfile)
    );


builder.Services.AddTransient<RedisConnection>();

builder.Services.AddCors(options =>
    options.AddPolicy("DEV_ALLOW_ALL", 
        builder => builder
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod())
);

builder.Services.AddDbContext<Context>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"),
                                 opt => opt.MigrationsAssembly("API.Gate")));
builder.Services.AddRepositories();


builder.Services.AddGQLService(options =>
{
    options.ConfigureSubscriptions = (sp, gqlBuilder) =>
    {
        gqlBuilder.AddRedisSubscriptions(_ =>
        {
            var con = new RedisConnection(builder.Configuration);
            var opt = con.GetConfigurationOptions();
            return ConnectionMultiplexer.Connect(opt);
        });
    };
    options.ConfigureDbContext = (sp, gqlBuilder) =>
    {
        gqlBuilder.RegisterDbContext<Context>();
    };
});

builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
#endregion


var app = builder.Build();

#region MiddleWare
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DEV_ALLOW_ALL");
app.UseHttpsRedirection();
app.UseWebSockets();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
#endregion

app.Run();
