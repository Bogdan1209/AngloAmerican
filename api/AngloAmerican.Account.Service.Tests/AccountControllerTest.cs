using AngloAmerican.Account.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AngloAmerican.Account.Service.Tests
{
    public class AccountControllerTest : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public AccountControllerTest(WebApplicationFactory<Api.Startup> fixture)
        {
            _server = new TestServer(new WebHostBuilder()
          .UseStartup<Startup>());
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
