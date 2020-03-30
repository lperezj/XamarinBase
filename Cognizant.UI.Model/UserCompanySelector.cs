using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FC.Weidekalender.UI.Model
{
    public class UserCompanySelector : INotifyPropertyChanged
    {
        private string companyName;
        private bool isSelected = false;

        public UserCompanySelector() { }

        public string CompanyName
        {
            get => companyName;
            set
            {
                companyName = value.TrimStart('0');
                OnPropertyChanged(nameof(CompanyName));
            }
        }

        public bool IsSelected 
        { 
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
