using FastTravel.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using FastTravel.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FastTravelContextConnection");
var FTDBconnectionString = builder.Configuration.GetConnectionString("FastTravelDatabaseConnection");

builder.Services.AddDbContext<FastTravelContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<FastTravelDbContext>(options =>
    options.UseSqlServer(FTDBconnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FastTravelContext>();

builder.Services.AddControllersWithViews();
AddAutorizationPolicies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


void AddAutorizationPolicies(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("adminOnly", policy => policy.RequireClaim("adminNum"));
    });
    services.AddAuthorization(options =>
    {
        options.AddPolicy("requireAdmin", policy => policy.RequireRole("Admin"));
        options.AddPolicy("requireUser", policy => policy.RequireRole("User"));
    });
}