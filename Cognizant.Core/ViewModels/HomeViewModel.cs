using System.Threading.Tasks;
using Cognizant.Core.ViewModels.Base;
using Cognizant.UI.Model.ReturnPageTypes;

namespace Cognizant.Core.ViewModels
{
    public class HomeViewModel : MvxBaseViewModel<object, ReturnTypeBase>
    {
        public HomeViewModel(IBaseViewModel parameters) : base(parameters)
        {

        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}