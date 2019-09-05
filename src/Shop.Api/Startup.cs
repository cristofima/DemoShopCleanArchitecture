using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.DTO;
using Shop.Core.Interfaces;
using Shop.Core.Interfaces.Repositories;
using Shop.Core.Interfaces.Services;
using Shop.Infrastructure;
using Shop.Infrastructure.Auth;
using Shop.Infrastructure.Data.Contexts;
using Shop.Infrastructure.Data.Identity;
using Shop.Infrastructure.Data.Repositories;
using Shop.Infrastructure.Services;
using System.Text;

namespace Shop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<DemoShopContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityCore<ApplicationUser>(config =>
            {
                config.SignIn.RequireConfirmedEmail = false;
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();

            // Get options from app settings
            var jwtOptions = Configuration.GetSection(nameof(JwtOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtOptions[nameof(JwtOptions.Issuer)];
                options.Key = jwtOptions[nameof(JwtOptions.Key)];
                options.ValidForMinutes = int.Parse(jwtOptions[nameof(JwtOptions.ValidForMinutes)]);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = jwtOptions[nameof(JwtOptions.Issuer)],
                       ValidAudience = jwtOptions[nameof(JwtOptions.Issuer)],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions[nameof(JwtOptions.Key)]))
                   };
               });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IJwtFactory, JwtFactory>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}