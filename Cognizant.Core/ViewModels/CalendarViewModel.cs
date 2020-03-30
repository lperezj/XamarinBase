using System.Threading.Tasks;
using Cognizant.Core.ViewModels.Base;
using Cognizant.UI.Model.ReturnPageTypes;
namespace Cognizant.Core.ViewModels
{
    public class CalendarViewModel : MvxBaseViewModel<object, ReturnTypeBase>
    {
        
        public CalendarViewModel(IBaseViewModel parameters) : base(parameters)
        {
        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}