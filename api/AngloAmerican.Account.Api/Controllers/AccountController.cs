using AngloAmerican.Common.Abstract;
using AngloAmerican.Account.Services;
using AngloAmerican.Account.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AngloAmerican.AccountType.Service.Abstract;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AngloAmerican.Account.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        /* TODO
            - Create a REST API to get all the accounts
                For every account you need to use AddressService to load an address (City and PostCode)
                You can use AccountResponse class
                
            - Create a REST API to save an account 
                Call BalanceChecker to verify if you can save
                You can use AccountRequest class as a payload
         */
        readonly private IAccountRepository _accountRepository;
        readonly private IAddressService _addressService;
        readonly private IAccountTypeService _accountTypeService;
        readonly private IMyBeautifulMapper _mapper;
        public AccountController(
            IAccountRepository accountRepository, 
            IAddressService addressService, 
            IMyBeautifulMapper mapper, 
            IAccountTypeService accountTypeService)
        {
            _addressService = addressService;
            _accountRepository = accountRepository;
            _accountTypeService = accountTypeService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountResponse>> Get()
        {
            var accounts = _accountRepository.GetAllAccounts();
            var accountDtos =_mapper.Map<AccountModel, AccountResponse>(accounts).ToList();

            //Partitioner can be useful if we have a lot of users;
            var rangePartitioner = Partitioner.Create(0, accountDtos.Count);

            await Task.Run(()=> Parallel.ForEach(rangePartitioner, async (range) =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    accountDtos[i].TypeId = _accountTypeService.GetTypeByBalance(accountDtos[i].Balance).Id;
                    accountDtos[i].Address = await _addressService.GetAddress();
                }
            }));

            return accountDtos;
        }

        public async Task Post(AccountRequest accountRequest)
        {
            var account = _mapper.Map<AccountRequest, AccountModel>(accountRequest);
            await _accountRepository.Add(account);
        }
    }
}