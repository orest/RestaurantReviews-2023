using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReviews.Data.Context;
using RestaurantReviews.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("RestaurantDb");
builder.Services.AddDbContext<RestaurantContext>(opt => {
    opt.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(
        options => {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Lockout.MaxFailedAccessAttempts = 5;

        }
    )
    .AddEntityFrameworkStores<RestaurantContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Accounts/Login"; // Specify your custom login path here
}); ;


builder.Services.AddScoped(p =>
    new MapperConfiguration(conf => {
        conf.AddProfile(new AutoMapperProfile());
    }).CreateMapper());


builder.Services.AddScoped<IRestaurantRepo, RestaurantRepo>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
//app.MapRazorPages();
app.Run();
