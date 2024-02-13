using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TenantAuthenticator.DI;
using TenantAuthenticator.Middleware;
using WebApplication1.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMainDbContext>(provider => provider.GetRequiredService<MainDBContext>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<MainDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb"),
    builder => builder.MigrationsAssembly(typeof(MainDBContext).Assembly.FullName));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

});

builder.Services.AddTenantDependencies(builder.Configuration);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCurrentTenantMiddleware();

app.MapControllers();

app.Run();
