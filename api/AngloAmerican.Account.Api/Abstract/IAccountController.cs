using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngloAmerican.Account.Api.Abstract
{
    public interface IAccountController
    {
        Task<IEnumerable<AccountResponse>> Get();
        Task Post(AccountRequest accountRequest);
    }
}
