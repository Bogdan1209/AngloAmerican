using AngloAmerican.Account.Services;
using AngloAmerican.Account.Services.Abstract;
using AngloAmerican.AccountType.Service;
using AngloAmerican.AccountType.Service.Abstract;
using AngloAmerican.Common.Abstract;
using AngloAmerican.Common.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AngloAmerican.Account.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options => options.AddDefaultPolicy(
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }));

            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddSingleton<IMyBeautifulMapper, MyBeautifulMapper>();
            services.AddSingleton<IAccountTypeService, AccountTypeService>();
            services.AddSingleton<IAccountTypeRepository, AccountTypeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
