using AngloAmerican.Account.Services.Abstract;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngloAmerican.Account.Services
{
    public class AddressService : IAddressService
    {
        private readonly IHttpClientFactory _clientFactory;
        public AddressService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /* TODO
            - Improve the usage of HttpClient in GetAddress method
         */
        public async Task<string> GetAddress()
        {
            var http = _clientFactory.CreateClient();
            var response = await http.GetAsync("https://randomuser.me/api/?nat=gb");
            var content = response.Content;
            var adr = await content.ReadAsStringAsync();

            var address = GetCityAndPostCode(adr);

            return address;
        }

        private string GetCityAndPostCode(string json)
        {
            try
            {
                dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
                dynamic city = jsonObject.results[0].location.city;
                dynamic postcode = jsonObject.results[0].location.postcode;

                var address = $"{city.ToString()} {postcode.ToString()}";

                return address;
            }
            catch
            {
                return "Data cannot be loaded";
            }
        }
    }
}
