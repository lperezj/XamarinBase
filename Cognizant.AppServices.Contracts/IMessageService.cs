using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cognizant.AppServices.Contracts
{
    public interface IMessageService
    {
        IMessagingCenter MessagingCenter { get; }
    }
}
