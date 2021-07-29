using AngloAmerican.AccountType.Service.Abstract;
using AngloAmerican.AccountType.Service.Models;
using System.Linq;

namespace AngloAmerican.AccountType.Service
{
    public class AccountTypeService: IAccountTypeService
    {
        public AccountTypeModel GetTypeByBalance(int balance)
        {
            var accountTypeRepository = new AccountTypeRepository();
            var accountTypes = accountTypeRepository.GetAllAccountTypes();

            if(balance < 5000)
            {
                return accountTypes.First(a => a.Name == "Bronze");
            }

            if(balance < 10000)
            {
                return accountTypes.First(a => a.Name == "Silver");
            }
            
            return accountTypes.First(a => a.Name == "Gold");
        }
    }
}
