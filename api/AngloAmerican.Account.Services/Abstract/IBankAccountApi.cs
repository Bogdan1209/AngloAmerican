using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Account.Services.Abstract
{
    public interface IBankAccountApi
    {
        bool CheckAccountBalance(int amount, string lastName);
    }
}
