using BlazorApp4.Components;
using BlazorApp4.Models;
using BlazorApp4.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AplicationDbContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddScoped<DonViTinhService>();
            builder.Services.AddScoped<LoaiSanPhamService>();
            builder.Services.AddScoped<SanPhamService>();
            builder.Services.AddScoped<NhaCungCapService>();
            builder.Services.AddScoped<KhoService>();
            builder.Services.AddScoped<NhapKhoService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<NhapKhoRawDataService>();
            builder.Services.AddScoped<XuatKhoService>();
            builder.Services.AddScoped<XuatKhoRawDataService>();
            builder.Services.AddScoped<KhoUserService>();


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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
