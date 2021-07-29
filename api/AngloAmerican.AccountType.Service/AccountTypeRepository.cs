using AngloAmerican.AccountType.Service.Abstract;
using AngloAmerican.AccountType.Service.Models;
using System.Collections.Generic;

namespace AngloAmerican.AccountType.Service
{
    public class AccountTypeRepository: IAccountTypeRepository
    {
        private List<AccountTypeModel> _accountTypes;

        public AccountTypeRepository()
        {
            CreateDefault();
        }

        private void CreateDefault()
            => _accountTypes = new List<AccountTypeModel>
            {
                new AccountTypeModel {Id = 1, Name = "Bronze"},
                new AccountTypeModel {Id = 2, Name = "Silver"},
                new AccountTypeModel {Id = 3, Name = "Gold"}
            };


        public List<AccountTypeModel> GetAllAccountTypes()
            => _accountTypes;

    }
}