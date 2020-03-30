
using System.Threading.Tasks;
using Cognizant.UI.Model.Enums;
using MvvmCross.ViewModels;

namespace Cognizant.Core.ViewModels.Base
{
    public class MvxBaseViewModel : MvxViewModel
    {

        public IBaseViewModel BaseViewModel { get; private set; }

        public MvxBaseViewModel(IBaseViewModel parameters)
        {
            this.BaseViewModel = parameters;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);
            this.InitializeTask.PropertyChanged -= this.InitializeTask_PropertyChanged;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
        }

        /// <summary>
        /// This method should be called in every View Code Behind when you
        /// need to subscribe to InitializeTask changes.
        /// </summary>
        public void OnViewModelSet()
        {
            if (this.InitializeTask is null)
            {
                return;
            }
            this.InitializeTask.PropertyChanged += this.InitializeTask_PropertyChanged;
        }
                
        private void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.InitializeTask.IsCompleted))
            {
                //this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<LoginViewModel>(); 
            }
        }

        /// <summary>
        /// It fires when a message is received from a type called <see cref="ApplicationEvents"/>
        /// Usually this type of message is sent from <see cref="App"/>
        /// </summary>
        /// <remarks>A general class is used to reuse common App events.</remarks>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual Task MessageReceivedShouldReloadAllData(ApplicationEvents obj) { return Task.CompletedTask; }
    }
}
