using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.Commands;
using Application.Email;
using Application.Interfaces;
using EfCommands;
using EntityFramework_DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            services.AddDbContext<Context>();
            services.AddTransient<IGetMoviesCommand, EfGetMoviesCommand>();
            services.AddTransient<ICreateMovieCommand, EfCreateMovieCommand>();
            services.AddTransient<IDeleteMovieCommand, EfDeleteMovieCommand>();
            services.AddTransient<IEditMovieCommand, EfEditMovieCommand>();

            services.AddTransient<ICreateActorCommand, EfCreateActorCommand>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();
            services.AddTransient<IGetActorsCommand, EfGetActorsCommand>();

            services.AddTransient<ICreateCinemaCommand, EfCreateCinemaCommand>();
            services.AddTransient<IGetCinemasCommand, EfGetCinemasCommand>();

            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            var section = Configuration.GetSection("Email");

            var sender = new SmtpEmailSender("smtp.gmail.com", 587, "t.sojic716@gmail.com", "sreckice");

            services.AddSingleton<IEmailSender>(sender);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
