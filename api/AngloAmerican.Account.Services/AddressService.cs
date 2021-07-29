using System.Net.Http;
using System.Threading.Tasks;
using AngloAmerican.Account.Services.Abstract;
using Newtonsoft.Json;

namespace AngloAmerican.Account.Services
{
    public class AddressService: IAddressService
    {

        /* TODO
            - Improve the usage of HttpClient in GetAddress method
         */
        public async Task<string> GetAddress()
        {
            var http = new HttpClient();
            var response =  await http.GetAsync("https://randomuser.me/api/?nat=gb");
            var content = response.Content;
            var adr = await content.ReadAsStringAsync();

            var address = GetCityAndPostCode(adr);

            return address;
        }

        private string GetCityAndPostCode(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic city = jsonObject.results[0].location.city;
            dynamic postcode = jsonObject.results[0].location.postcode;

            var address = $"{city.ToString()} {postcode.ToString()}";

            return address;
        }
    }
}
