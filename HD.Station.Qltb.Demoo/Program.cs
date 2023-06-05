using Microsoft.EntityFrameworkCore;
using HD.Station.Qltb.SqlServer;
using HD.Station.Qltb.Abstractions.Stores;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QltbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLTBContext") ?? throw new InvalidOperationException("Connection string 'QLTBContext' not found.")));
builder.Services.Configure<RazorViewEngineOptions>(o =>
{
    o.AreaViewLocationFormats.Clear();
    o.ViewLocationFormats.Add("~/Views/{0}" + RazorViewEngine.ViewExtension);
    o.ViewLocationFormats.Add("~/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
    o.AreaViewLocationFormats.Add("/Features/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    o.AreaViewLocationFormats.Add("/Features/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
    o.AreaViewLocationFormats.Add("/Features/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
    o.AreaViewLocationFormats.Add("/Features/Shared/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddTransient<IDeviceStore, DeviceStore>();
builder.Services.AddTransient<IDeviceManagement, DeviceManagement>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyFeatures",
    pattern: "{area:exists=Qltb}/{controller=Qltb}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Qltb}/{action=Index}/{id?}");

app.Run();
