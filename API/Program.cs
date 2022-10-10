using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using API.Services;
using AutoMapper;
using API;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper
{
    var mapperConfiguration = new MapperConfiguration(cfg =>
                    cfg.AddProfile(new MappingProfile())
                );
    IMapper mapper = mapperConfiguration.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddRazorPages();

// DB Context(s)
{
    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection")));
}

// API Services
{
    builder.Services.AddScoped<IEmployeesService, EmployeesService>();
    builder.Services.AddScoped<IEmployeeAttendanceService, EmployeeAttendanceService>();
    builder.Services.AddScoped<IJustificationService, JustificationService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();
    //app.MapRazorPages();
    app.Run();
}
