using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Account.Services.Abstaract
{
    public interface IBankAccountApi
    {
        bool CheckAccountBalance(int amount, string lastName);
    }
}
