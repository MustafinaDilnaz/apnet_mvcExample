using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MVCExample;
using MVCExample.Data;
using MVCExample.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var config = builder.Configuration;
var connection = config.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));

  

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

app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "Img")
    ),
  RequestPath = new PathString("/Img")
});

app.Use(async (context, next) =>
{
  var cultureQuery = context.Request.Query["culture"];
  if (!string.IsNullOrEmpty(cultureQuery))
  {
    var culture = new CultureInfo(cultureQuery);
    CultureInfo.CurrentCulture = culture;
    CultureInfo.CurrentUICulture = culture;
    context.Response.Headers["myCulture"] = cultureQuery; 
  }
  await next(context);
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var services = app.Services.CreateScope().ServiceProvider;
var context = services.GetRequiredService<MobileContext>();
SampleData.Initialize(context);

app.Run();

//Ya Madiyar dobavil iz, smotrite


