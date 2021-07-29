using AngloAmerican.Account.Services;
using AngloAmerican.Account.Services.Abstaract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Account.Service.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBankAccountApi, BankAccountApi>();
            services.AddTransient<IBalanceChecker, BalanceChecker>();
        }
    }
}
