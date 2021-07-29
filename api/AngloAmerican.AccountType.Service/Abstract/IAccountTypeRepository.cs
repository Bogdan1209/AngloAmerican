using AngloAmerican.AccountType.Service.Models;
using System.Collections.Generic;

namespace AngloAmerican.AccountType.Service.Abstract
{
    public interface IAccountTypeRepository
    {
        List<AccountTypeModel> GetAllAccountTypes();
    }
}
