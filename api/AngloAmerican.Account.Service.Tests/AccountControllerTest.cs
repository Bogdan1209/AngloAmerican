using AngloAmerican.Account.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AngloAmerican.Account.Service.Tests
{
    public class AccountControllerTest : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient _client;
        public AccountControllerTest(WebApplicationFactory<Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_ListOfAccounts()
        {
            var request = "/accounts";
            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            var forecast = JsonConvert.DeserializeObject<AccountModel[]>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(forecast);
        }
    }
}
