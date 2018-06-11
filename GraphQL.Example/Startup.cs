using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Example.DAL;
using Example.DAL.Models.Interfaces;
using GraphQL.Example.Repository.Interface;
using Example.DAL.Models;
using GraphQL.Example.Repository;
using GraphQL.Example.GraphModel;
using GraphQL.Example.GraphModel.Types;
using GraphQL.Types;

namespace GraphQL.Example
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc();

            services.AddDbContext<BookContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRepository<Book>, BookRepository>();
            services.AddTransient<IRepository<Author>, AuthorRepository>();
            services.AddSingleton<RepositoryContext>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GraphQuery>();
            services.AddSingleton<GraphMutation>();
            services.AddSingleton<BookType>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<BookInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

            app.UseMvc();
        }
    }
}
