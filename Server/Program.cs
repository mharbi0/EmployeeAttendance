using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Authorization;
using Server.Roles;

var builder = WebApplication.CreateBuilder(args);

// DB Context(s)
{
    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection")));
}

// Microsoft.AspNetCore.Identity configuration
{
    IdentityBuilder identityBuilder = builder.Services.AddIdentityCore<Employee>();

    identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>();
    identityBuilder.AddDefaultUI();
    identityBuilder.Services.AddAuthentication()
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
             options => builder.Configuration.Bind("JwtSettings", options))
     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
         options =>
         {
             //options.LoginPath = new PathString("/auth/login");
             //options.AccessDeniedPath = new PathString("/auth/denied");
         });
    identityBuilder.Services.AddAuthorization();
    identityBuilder.Services.AddLogging();
    identityBuilder.AddDefaultTokenProviders();
    identityBuilder.AddRoles<AdministratorRole>();
    identityBuilder.AddRoles<EmployeeRole>();

    //{

    //    options.SignIn.RequireConfirmedEmail = false;
    //    options.SignIn.RequireConfirmedPhoneNumber = false;
    //    options.SignIn.RequireConfirmedAccount = false;


    //});
    //.AddEntityFrameworkStores<ApplicationDbContext>()
    //.AddDefaultTokenProviders()
    //.Services.AddAuthentication(options =>
    //{
    //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //});


    //identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole), builder.Services);
    //identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

    //builder.Services.Configure<IdentityOptions>(options =>
    //{
    //    options.SignIn.RequireConfirmedEmail = false;
    //    options.SignIn.RequireConfirmedPhoneNumber = false;
    //    options.SignIn.RequireConfirmedAccount = false;

    //    // Default Lockout settings.
    //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //    //options.Lockout.MaxFailedAccessAttempts = 5;
    //    //options.Lockout.AllowedForNewUsers = true;

    //    // Default Password settings.
    //    //options.Password.RequireDigit = true;
    //    //options.Password.RequireLowercase = true;
    //    //options.Password.RequireNonAlphanumeric = true;
    //    //options.Password.RequireUppercase = true;
    //    //options.Password.RequiredLength = 6;
    //    //options.Password.RequiredUniqueChars = 1;

    //    // Default SignIn settings.
    //    //options.SignIn.RequireConfirmedEmail = false;
    //    //options.SignIn.RequireConfirmedPhoneNumber = false;

    //    // Default User settings.
    //    //options.User.AllowedUserNameCharacters =
    //    //        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //    //options.User.RequireUniqueEmail = false;
    //});



    //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    // .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
    //         options => builder.Configuration.Bind("JwtSettings", options))
    // .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    //     options =>
    //     {
    //         //options.LoginPath = new PathString("/auth/login");
    //         //options.AccessDeniedPath = new PathString("/auth/denied");
    //     });
}

// Razor Pages
{
	builder.Services.AddRazorPages();
}

var app = builder.Build();

{
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}
	
	app.UseHttpsRedirection();
	app.UseStaticFiles();

	app.UseRouting();
	app.UseAuthentication();;

	app.UseAuthorization();

	app.MapRazorPages();

}

//app.MapGet("/", () => "Hello World!");

app.Run();
