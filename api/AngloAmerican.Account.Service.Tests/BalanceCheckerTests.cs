using AngloAmerican.Account.Services.Abstract;
using Moq;
using System;
using Xunit;

namespace AngloAmerican.Account.Service.Tests
{
    public class BalanceCheckerTests
    {
        private readonly IBalanceChecker _balanceChecker;
        private readonly Mock<IBankAccountApi> _mockBankAccountApi;
        private readonly Mock<INotificationService> _mockNotificationService;
        public BalanceCheckerTests(IBalanceChecker balanceChecker) { 
            _balanceChecker = balanceChecker;
            _mockNotificationService = new Mock<INotificationService>();
            _mockBankAccountApi = new Mock<IBankAccountApi>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9999)]
        public void Process_AmountLess10000_SendEmail(int amount)
        {
            var result = _balanceChecker.Process(amount, _mockNotificationService.Object, _mockBankAccountApi.Object, It.IsAny<string>());

            _mockNotificationService.Verify(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Theory]
        [InlineData(10001)]
        [InlineData(99999)]
        public void Process_AmountMore10000_SendMessage(int amount)
        {
            var result = _balanceChecker.Process(amount, _mockNotificationService.Object, _mockBankAccountApi.Object, It.IsAny<string>());

            _mockNotificationService.Verify(m => m.SendMessage(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void Process_AmountIs10000_DontNotifyUser()
        {
            var result = _balanceChecker.Process(10000, _mockNotificationService.Object, _mockBankAccountApi.Object, It.IsAny<string>());

            _mockNotificationService.Verify(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            _mockNotificationService.Verify(m => m.SendMessage(It.IsAny<string>()), Times.Never());
        }
    }
}
