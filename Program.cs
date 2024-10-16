using BlazorBookSale.Components;
using BlazorBookSale.Models;
using BlazorBookSale.Repositories;
using BlazorBookSales.Reponsitories;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.AddDbContext<BookSalesContext>(options.UseMySQL(builder.Configuration.GetConnectionString("DBConnection")));
// builder.Services.AddDbContext<BooksalesContext>(Options.UseMySQL(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddDbContext<BooksalesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DBConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DBConnection"))));

builder.Services.AddScoped<IBookSaleRepository, BookSaleReponsitory>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();



