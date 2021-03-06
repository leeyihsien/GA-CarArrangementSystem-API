using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API._Repositories.Interface;
using GA_CarArrangementSystem_API._Repositories.Interface.DbUser;
using GA_CarArrangementSystem_API._Repositories.Repositories;
using GA_CarArrangementSystem_API._Repositories.Repositories.DbUser;
using GA_CarArrangementSystem_API._Services.Interface;
using GA_CarArrangementSystem_API._Services.Services;
using Microsoft.EntityFrameworkCore.SqlServer;
using AutoMapper;
using GA_CarArrangementSystem_API.Helpers.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GA_CarArrangementSystem_API
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
            services.AddCors();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));

            services.AddControllers()
            .AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            //register automapper 
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IMapper>(sp => {
                return new Mapper(AutoMapperConfig.RegisterMappings());
            });
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options => {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                   .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });


            //Repository DI
            services.AddScoped<IArrangementInfoRepository, ArrangementInfoRepository>();
            services.AddScoped<ICarInfoRepository, CarInfoRepository>();
            services.AddScoped<IRouteInfoRepository, RouteInfoRepository>();
            services.AddScoped<IDriverInfoRepository, DriverInfoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();
            services.AddScoped<IRouteScheduleRepository, RouteScheduleRepository>();


            // Service 
            services.AddScoped<IArrangementInfoService, ArrangementInfoService>();
            services.AddScoped<ICarInfoService, CarInfoService>();
            services.AddScoped<IDriverInfoService, DriverInfoService>();
            services.AddScoped<IRouteInfoService, RouteInfoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRouteScheduleService, RouteScheduleService>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Image")),
                RequestPath = "/Image"
            });
        }
    }
}
