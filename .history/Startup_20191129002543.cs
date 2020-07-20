using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseCleanersApi.BusinessLayer;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using HouseCleanersApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using  Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Seeder = HouseCleanersApi.Data.Seeder;
using User = HouseCleanersApi.Data.User;



namespace HouseCleanersApi
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
            
             services.AddControllers();
            // Add framework services.
            services.AddDbContext<clearnersDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("NpgsqlConnection")));

           services.AddIdentity<User, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
              .AddEntityFrameworkStores<clearnersDbContext>();
           services.AddAuthentication(
                   option => {
                       option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                       option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                       option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
               .AddCookie()
               .AddJwtBearer(cfg=>
                   {
                       cfg.SaveToken = true;
                       cfg.RequireHttpsMetadata = true;
                       cfg.TokenValidationParameters = new TokenValidationParameters()
                       {
                           ValidIssuer = Configuration["Tokens:Issuer"],
                           ValidAudience = Configuration["Tokens:Audience"],
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:key"]))
                       };
                   }
               );
            services.AddTransient<Seeder>();
            services.AddScoped<IGeneralRepository, GeneralRepository>(); // activation le service des service, en appelant l'interface on instancie la classe. 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(doc =>
                doc.SwaggerDoc("v1", new OpenApiInfo {Title = "DocumentationApi", Version = "v1"}));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<Seeder>();
                    seeder.Seed().Wait();
                }
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(doc => doc.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentationApi v1"));
            
            
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
