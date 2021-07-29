using AngloAmerican.Account.Services.Abstaract;
//using AngloAmerican.Account.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngloAmerican.Account.Services
{
    /* TODO
        - Refactor the class and add Unit Tests
    */
    public class BalanceChecker : IBalanceChecker
    {
        public bool Process(int amount, INotificationService notificationService, IBankAccountApi externalApi, string lastName)
        {
            //We can create struct like FakeDateTime to test it, but i'm not sure it's really good idea.
            var emailTitle = DateTime.Now.Day < 15 ?
                "<h1>Info about days till Middle of the month</h1>" :
                "<h1>Info about days till End of the month</h1>";

            var emailBody = "<p>Body placeholder<p>";

            if (amount > 10000)
            {
                var message = emailTitle + "\n" + emailBody;
                notificationService.SendMessage(message);
                return externalApi.CheckAccountBalance(amount, lastName);
            }

            if (amount < 10000)
            {
                notificationService.SendEmail(emailTitle, emailBody);
            }

            return true;
        }
    }

    public class NotificationService : INotificationService
    {
        public void SendEmail(string title, string body)
        {
            // it sends an email
        }

        public void SendMessage(string message)
        {
            // it sends a message
        }
    }


    // TODO: Improve and make the code more readable.
    public class BankAccountApi : IBankAccountApi
    {
        private List<string> _names = new List<string> { "Rene", "Kirk", "Escarole" };

        public bool CheckAccountBalance(int amount, string lastName)
        {
            //Using negative conditions is bad practice.
            //return !_names.Any(n => n == lastName && amount >= 10000);

            if (_names.Any(n => n == lastName))
            {
                return amount <= 10000;
            }

            return true;
        }
    }
}