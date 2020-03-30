using System;
namespace Cognizant.UI.Model.ReturnPageTypes
{
    public class ReturnTypeBase
    {
        private readonly string fromViewModel;

        public ReturnTypeBase()
        {
            this.fromViewModel = this.GetType().FullName;
        }
    }
}
