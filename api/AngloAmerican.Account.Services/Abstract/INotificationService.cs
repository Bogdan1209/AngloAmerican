using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Account.Services.Abstract
{
    public interface INotificationService
    {
        void SendEmail(string title, string body);
        void SendMessage(string message);
    }
}
