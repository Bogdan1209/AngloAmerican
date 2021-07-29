using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Account.Services.Abstaract
{
    public interface IBalanceChecker
    {
        bool Process(int amount, INotificationService notification, IBankAccountApi eA, string lastName);

    }
}
