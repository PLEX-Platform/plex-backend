using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Interfaces;
using PlexBackend.Core.Services;
using PlexBackend.Infrastructure;
using PlexBackend.Infrastructure.Helpers;
using PlexBackend.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PlexBackend.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /// <summary>
            /// Setup Dbcontext class depending on the environment
            /// </summary>
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PlexContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalDb")));
            }
            else
            {
                services.AddDbContext<PlexContext>(optionsbuilder =>
                {
                    optionsbuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
            }

            /// <summary>
            /// Adding cors and defining the used policy
            /// </summary>
            services.AddCors(o => o.AddPolicy("AllowEverythingPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));


            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IStudentChoiceService, StudentChoiceService>();
            services.AddScoped<IStudentChoiceRepository, StudentChoiceRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IMatchMakingService, MatchMakingService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlexBackend.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app,env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlexBackend.WebApi v1"));
            }
            app.UseCors("AllowEverythingPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }

        /// <summary>
        /// Applies new migrations or if no LocalDb exists creates the database
        /// </summary>
        private static void UpdateDatabase(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using IServiceScope serviceScope = app.ApplicationServices
                                                  .GetRequiredService<IServiceScopeFactory>()
                                                  .CreateScope();
            using PlexContext context = serviceScope.ServiceProvider.GetService<PlexContext>();
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                if (!context.Students.Any())
                {
                    context.Students.AddRange(Seed.SeedStudents());
                    context.SaveChanges();
                }

                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(Seed.SeedProjects());
                    context.SaveChanges();
                }

                if (!context.Playlists.Any())
                {
                    List<Project> projects = context.Projects.ToList();
                    context.Playlists.AddRange(Seed.SeedPlaylists(projects));
                    context.SaveChanges();
                }

                if (!context.StudentChoices.Any())
                {
                    context.StudentChoices.AddRange(Seed.SeedStudentChoices());
                    context.SaveChanges();
                }
            }
        }
    }
}