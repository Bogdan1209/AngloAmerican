using System.Net.Http;
using Newtonsoft.Json;

namespace AngloAmerican.Account.Services
{
    public class AddressService
    {

        /* TODO
            - Improve the usage of HttpClient in GetAddress method
         */
        public string GetAddress()
        {
            var http = new HttpClient();
            var response = http.GetAsync("https://randomuser.me/api/?nat=gb");
            var content = response.Result.Content;
            var adr = content.ReadAsStringAsync().Result;

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
