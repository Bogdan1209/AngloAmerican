using AngloAmerican.Account.Api.Abstract;
using AngloAmerican.Account.Api.Controllers;
using AngloAmerican.Account.Services;
using AngloAmerican.Account.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AngloAmerican.Account.Service.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBankAccountApi, BankAccountApi>();
            services.AddTransient<IBalanceChecker, BalanceChecker>();
            services.AddTransient<IAccountController, AccountController>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
