using API.Gate.GraphQl;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
    options.AddDefaultPolicy(builder =>builder
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod())
);

builder.Services.AddDbContext<Context>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"), 
                                 opt => opt.MigrationsAssembly("API.Gate")));

builder.Services.AddGraphQLServer()
                .RegisterDbContext<Context>()
                .AddQueryType<UsersQuery>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
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

/*#region Migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Context>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
#endregion*/

app.Run();
