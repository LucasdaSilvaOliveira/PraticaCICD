using PraticaCICD.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddHttpClient<RoupaService>(options =>
//{
//    options.BaseAddress = new Uri("https://localhost:7256");
//});

builder.Services.AddHttpClient("RoupaService", httpCliente =>
{
    httpCliente.BaseAddress = new Uri("https://localhost:7256/");
});

builder.Services.AddScoped<IRoupaService, RoupaService>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
