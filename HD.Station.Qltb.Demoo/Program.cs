using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using HD.Station.Qltb.SqlServer;
using HD.Station.Qltb.Abstractions.Stores;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.Services;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Security;
using HD.Station.Qltb.Demoo.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(builder.Configuration.GetConnectionString("QLTBContext"));
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
builder.Services.AddTransient<IUserManagement, UserManagement>();
builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.ConfigureOptions<JwtOptionsSetup>()
    .ConfigureOptions<JwtBearerOptionsSetup>()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
  ;

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
app.UseCors(
    x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyFeatures",
    pattern: "{area:exists=Qltb}/{controller=Qltb}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Qltb}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  try
  {
      var deviceStore = services.GetRequiredService<IDeviceStore>();
      IEnumerable<Thietbi?>? deviceList = await deviceStore.GetAllDevices();
      foreach (var tb in deviceList)
      {
          Console.WriteLine(tb?.Tentb);
      }

  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.ToString());
  }
}
app.Run();
