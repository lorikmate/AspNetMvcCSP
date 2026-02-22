using AspNetMvcCSP.Middlewares;
using AspNetMvcCSP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add a guid per instance to see instance id on pages, not really needed
// could use ENV var coming from Docker, this is just for running multiple
// instances locally
builder.Services.AddSingleton<IGuidSingleton, GuidSingleton>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware to add nonce + instance id per request
app.UseMiddleware<RequestMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
