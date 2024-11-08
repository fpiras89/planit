using GraphQL;
using Planit.Application.Interfaces;
using Planit.Persistence;
using Planit.Presentation.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Query>(c => c.WithMutation<Mutation>())
    .AddSystemTextJson()
    .UseTelemetry()
);

/*builder.Services.AddDbContext<ApplicationDbContext>(b => b                 
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    {
        options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
    }));
builder.Services.AddScoped<IDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQL("/graphql");

app.Run();

public partial class Program { }