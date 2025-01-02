using GraphQL;
using Microsoft.EntityFrameworkCore;
using Planit.Application.Interfaces;
using Planit.Infrastructure;
using Planit.Persistence;
using Planit.Persistence.Services;
using Planit.Presentation.GraphQL;
using Planit.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Query>(c => c.WithMutation<Mutation>())
    .AddErrorInfoProvider(options =>
    {
        options.ExposeExceptionDetails = builder.Environment.IsDevelopment();
        options.ExposeData = true;
        options.ExposeExtensions = true;
        options.ExposeCode = true;
    })
    .ConfigureExecutionOptions(options =>
    {
        var logger = options.RequestServices!.GetRequiredService<ILogger<Program>>();
        options.UnhandledExceptionDelegate = ctx =>
        {
            logger.LogError("GraphQL Unhandled Exception: {ErrorMessage} | {OriginalExceptionMessage}", ctx.ErrorMessage, ctx.OriginalException.Message);
            logger.LogError(ctx.Context.Document.ToString());
            return Task.CompletedTask;
        };
    })
    .AddSystemTextJson()
    .UseTelemetry()
);

builder.Services.AddDbContext<ApplicationDbContext>(b => b 
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    {
        options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
    }));
builder.Services.AddScoped<IDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

builder.Services.AddHostedService<ApplicationInitializer>();
builder.Services.AddScoped<IApplicationInitializer, MigrationsService>();

builder.Services.AddApplicationServices();

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