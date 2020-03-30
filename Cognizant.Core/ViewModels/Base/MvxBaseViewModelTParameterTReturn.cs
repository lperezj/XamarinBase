using MvvmCross.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using Cognizant.UI.Model.Enums;
using Cognizant.UI.Model.ReturnPageTypes;
using Cognizant.Common.Constants;

namespace Cognizant.Core.ViewModels.Base
{
    public class MvxBaseViewModel<TParameter, TReturn> : MvxViewModel<TParameter, TReturn>
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
        /// It fires before Initialize to fill sent data from previous View Model
        /// </summary>
        /// <param name="parameter"></param>
        public override void Prepare(TParameter parameter) { }

        /// <summary>
        /// It fires after going back from next View Model.
        /// Commonly used when navigation type is like:
        /// "var result = await NavigationService.MvxNavigationService.Navigate(TargetViewModel,TParameter,TResult)(parameter_to_send)"
        /// </summary>
        /// <param name="result"></param>
        public virtual Task ReturningToViewModel(ReturnTypeBase result) { return Task.CompletedTask; }

        /// <summary>
        /// It fires when a message is received from a type called <see cref="ApplicationEvents"/>
        /// Usually this type of message is sent from <see cref="App"/>
        /// </summary>
        /// <remarks>A general class is used to reuse common App events.</remarks>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual Task MessageReceivedShouldReloadAllData(ApplicationEvents obj)
        {
            return Task.CompletedTask;
        }
    }
}
