using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingCoreApi.Models;
using OnlineShoppingCoreApi.Models.Repository;

namespace OnlineShoppingCoreApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<OnlineShoppingCoreApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbCon")));
            services.AddScoped<IDataAccessRepository<Category>, ClsCategoryRepository>();
            services.AddScoped<IDataAccessRepository<Brand>, ClsBrandRepository>();
            services.AddScoped<IDataAccessRepository<Customer>, ClsCustomerRepository>();
            services.AddScoped<IDataAccessRepository<Item>, ClsItemRepository>();
            services.AddScoped<IDataAccessRepository<Stock>, ClsStockRepository>();
            services.AddScoped<IDataAccessRepository<Supplier>, ClsSupplierRepository>();
            services.AddScoped<IDataAccessRepository<Purchase>, ClsPurchaseRepository>();
            services.AddScoped<IDataAccessRepository<Payment>, ClsPaymentRepository>();
            services.AddScoped<IDataAccessRepository<OrderDetail>, ClsOrderDetailsRepository>();
            //services.AddScoped<IDataAccessRepository<OrderArchive>, ClsOrderArchiveRepository>();
            services.AddScoped<IDataAccessRepository<Shippment>, ClsShippmentRepository>();
            services.AddScoped<IDataAccessRepository<CancelOrder>, ClsCancelOrderRepository>();


            services.AddDbContext<OnlineShoppingCoreApiDbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DbCon")));
            services.AddIdentity<IdentityUser, IdentityRole>(
                option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 6;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireLowercase = false;
                }
                ).AddEntityFrameworkStores<OnlineShoppingCoreApiDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Site"],
                    ValidIssuer = Configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigninKey"]))
                };
            });
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
