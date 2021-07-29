using AngloAmerican.AccountType.Service.Models;

namespace AngloAmerican.AccountType.Service.Abstract
{
    public interface IAccountTypeService
    {
        AccountTypeModel GetTypeByBalance(int balance);
    }
}
