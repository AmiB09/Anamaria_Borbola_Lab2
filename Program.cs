using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Anamaria_Borbola_Lab2.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Anamaria_Borbola_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Anamaria_Borbola_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Anamaria_Borbola_Lab2Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
