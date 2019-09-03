using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using Draft.Inf.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Draft.Core.SharedKernel;
using Draft.Inf.Services;
using Draft.Core.Services;
using Draft.Inf.Identity;
using Draft.Web.Api;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Draft.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });

            services.AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.ClaimsIssuer = Configuration["Authentication:JwtIssuer"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Authentication:JwtIssuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Authentication:JwtAudience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtKey"])),
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            var provider = BuildDIProvider(services);
            IdentitySeeder.UserManager = provider.GetService<UserManager<AppUser>>();
            IdentitySeeder.RoleManager = provider.GetService<RoleManager<AppRole>>();
            return provider;
        }

        private static IServiceProvider BuildDIProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            Assembly webAssembly = Assembly.GetExecutingAssembly();
            Assembly coreAssembly = Assembly.GetAssembly(typeof(Entity));
            Assembly infAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            builder.RegisterAssemblyTypes(webAssembly, coreAssembly, infAssembly)
                .AsImplementedInterfaces();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();


            builder.RegisterType<LeagueService>();
            builder.RegisterType<WaiverService>();
            builder.RegisterType<TeamService>();
            builder.RegisterType<TimerService>()
                .AsImplementedInterfaces()
                .SingleInstance();


            IContainer applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();


            app.UseSignalR(routes =>
            {
                routes.MapHub<TimerHub>("/hubs/timer");
                routes.MapHub<SeasonHub>("/hubs/season");
                routes.MapHub<TeamClaimHub>("/hubs/teamclaim");
                routes.MapHub<TeamHub>("/hubs/teams");
                routes.MapHub<WaiverHub>("/hubs/waiver");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            var db = provider.GetService<AppDbContext>();
            db.SeedIdentity();
            db.InitLeague();
        }
    }
}
