using System.Diagnostics;
using System.Threading.Tasks;
using Cognizant.Common.Constants;
using Cognizant.UI.Model.Enums;
using MvvmCross.ViewModels;

namespace Cognizant.Core.ViewModels.Base
{
    public class MvxBaseViewModel<TParameter> : MvxViewModel<TParameter>
    {
        public IBaseViewModel BaseViewModel { get; private set; }

        public MvxBaseViewModel(IBaseViewModel parameters)
        {
            this.BaseViewModel = parameters;
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

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);
            this.InitializeTask.PropertyChanged -= this.InitializeTask_PropertyChanged;
        }

        private void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.InitializeTask.IsCompleted))
            {
                //this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<LoginViewModel>(); 
            }
        }

        /// <summary>
        /// Fires before Initialize to fill sent data from previous View Model
        /// </summary>
        /// <param name="parameter"></param>
        public override void Prepare(TParameter parameter) { }

        /// <summary>
        /// It fires when a message is received from a type called <see cref="ApplicationEvents"/>
        /// Usually this type of message is sent from <see cref="App"/>
        /// </summary>
        /// <remarks>A general class is used to reuse common App events.</remarks>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected virtual Task MessageReceivedShouldReloadAllData(ApplicationEvents obj) { return Task.CompletedTask; }
    }
}
