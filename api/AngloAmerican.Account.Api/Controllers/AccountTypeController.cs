using System.Collections.Generic;
using System.Threading.Tasks;
using AngloAmerican.AccountType.Service.Abstract;
using AngloAmerican.AccountType.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngloAmerican.Account.Api.Controllers
{
    [ApiController]
    [Route("accounttype")]
    public class AccountTypeController : ControllerBase
    {
        readonly private IAccountTypeRepository _accountTypeRepository;
        public AccountTypeController(
            IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public List<AccountTypeModel> Get()
        {
            return _accountTypeRepository.GetAllAccountTypes();
        }
        
    }
}