using HRManager.Data;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Identity; // Añadir este using
>>>>>>> jhei

namespace HRManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

<<<<<<< HEAD
            builder.Services.AddDbContext<HRManagerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HRManagerDB"))
            );

=======
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Añadir Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = false // Puedes cambiar esto después
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();  // Añadir la interfaz de usuario por defecto de Identity
>>>>>>> jhei

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Añadir esto antes de UseAuthorization
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers(); // Añadir esto si usas controladores (necesario para la UI de Identity)

            app.Run();
        }
    }
}