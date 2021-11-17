using System;
using System.Net.Http;
using System.Text;
using AutoMapper;
using Data.Collection.From.Rest.Api.Template.Context;
using Data.Collection.From.Rest.Api.Template.Mappings;
using Data.Collection.From.Rest.Api.Template.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Collection.From.Rest.Api.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading appsettings.json
            var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", false, true);
    
            var config = builder.Build();
            var connectionString = config["ConnectionString"];
            

            // Adding mapper
            var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
            IMapper mapper = mapperConfig.CreateMapper();
            
            // Creating HttpClient
            var client = new HttpClient();
            // configuring client, adding basic auth from appsettings.json 
            var byteArray = Encoding.ASCII.GetBytes($"{config["RestAuthentication:Username"]}:{config["RestAuthentication:Password"]}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // Adding services
            var services = new ServiceCollection();
            services.AddSingleton(mapper);
            services.AddSingleton(client);
            services.AddSingleton(connectionString);
            services.AddSingleton<TemplateService>();

            // Adding DbContext Service
            services.AddDbContext<TemplateDbContext>(
                options => options.UseSqlServer(connectionString));



            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var templateService = serviceProvider.GetService<TemplateService>();

        }
    }
}
