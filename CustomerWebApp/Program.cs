var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options => {
    options.Cookie.Name = ".HotelApp";
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
