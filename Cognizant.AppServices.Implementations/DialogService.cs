using System;
using Acr.UserDialogs;
using Cognizant.AppServices.Contracts;

namespace Cognizant.AppServices.Implementations
{
    public class DialogService : IDialogService
    {
        protected readonly IUserDialogs UserDialogs;

        public DialogService()
        {
            this.UserDialogs = Acr.UserDialogs.UserDialogs.Instance;
        }

        public IDisposable ConfirmDialog(string title, string message, string okText, string cancelText, Action<bool> action)
        {
            ConfirmConfig config = new ConfirmConfig()
            {
                Title = title,
                Message = message,
                OkText = okText,
                CancelText = cancelText,
                OnAction = action
            };

            return this.UserDialogs.Confirm(config);
        }

        public IProgressDialog Loading(string title = null)
        {
            return this.UserDialogs.Loading(title);
        }

        public IProgressDialog LoadingWithCancellation(string title, string cancelText, Action onCancel = null, bool show = true, MaskType? maskType = default)
        {           
            return this.UserDialogs.Loading(title, onCancel, cancelText, show, maskType);
        }
    }
}