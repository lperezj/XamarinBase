using System;
using Acr.UserDialogs;

namespace Cognizant.AppServices.Contracts
{
    public interface IDialogService
    {
        IProgressDialog Loading(string title = null);

        IProgressDialog LoadingWithCancellation(string title, string cancelText, Action onCancel = null, bool show = true, MaskType? maskType = default);

        IDisposable ConfirmDialog(string title, string message, string okText, string cancelText, Action<bool> action);
    }
}