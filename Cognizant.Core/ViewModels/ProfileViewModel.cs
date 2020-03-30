using System.Threading.Tasks;
using Cognizant.Core.ViewModels.Base;

namespace Cognizant.Core.ViewModels
{
    public class ProfileViewModel : MvxBaseViewModel
    {
        public ProfileViewModel(IBaseViewModel parameters) : base(parameters)
        {
            
        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}