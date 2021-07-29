using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AngloAmerican.Account.Services.Abstract
{
    public interface IAddressService
    {
        Task<string> GetAddress();
    }
}
