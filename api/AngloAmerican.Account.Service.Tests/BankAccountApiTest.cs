using AngloAmerican.Account.Services.Abstaract;
using Xunit;

namespace AngloAmerican.Account.Service.Tests
{
    public class BankAccountApiTest
    {
        private readonly IBankAccountApi _bankAccountApi;
        public BankAccountApiTest(IBankAccountApi bankAccountApi) => _bankAccountApi = bankAccountApi;

        [Theory]
        [InlineData(0)]
        [InlineData(99999)]
        public void CheckAccountBalance_WrongName_True(int amount)
        {
            Assert.True(_bankAccountApi.CheckAccountBalance(amount, string.Empty));
            Assert.True(_bankAccountApi.CheckAccountBalance(amount, string.Empty));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10000)]
        public void CheckAccountBalance_AmountLessThen10001_True(int amount)
        {
            Assert.True(_bankAccountApi.CheckAccountBalance(amount, "Rene"));
            Assert.True(_bankAccountApi.CheckAccountBalance(amount, "Rene"));
        }

        [Theory]
        [InlineData(10001)]
        [InlineData(999999)]
        public void CheckAccountBalance_AmountMoreThen10000_False(int amount)
        {
            Assert.False(_bankAccountApi.CheckAccountBalance(amount, "Rene"));
            Assert.False(_bankAccountApi.CheckAccountBalance(amount, "Rene"));
        }
    }
}
