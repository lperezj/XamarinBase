using Cognizant.AppServices.Contracts;
using Xamarin.Forms;

namespace Cognizant.AppServices.Implementations
{
    public class MessageService : IMessageService
    {
        public IMessagingCenter MessagingCenter 
        {
            get
            {
                return Xamarin.Forms.MessagingCenter.Instance;
            }
        }

        public MessageService()
        {
            
        }
    }
}
