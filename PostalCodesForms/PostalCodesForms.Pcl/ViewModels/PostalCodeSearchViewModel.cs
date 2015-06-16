using PostalCodesForms.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using PostalCodesForms.Services;
using System;

namespace PostalCodesForms.ViewModels
{
    public class PostalCodeSearchViewModel : INotifyPropertyChanged
    {
        public event EventHandler ErrorOccurred;

        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (city != value)
                {
                    city = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string province;
        public string Province
        {
            get
            {
                return province;
            }
            set
            {
                if (province != value)
                {
                    province = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (country != value)
                {
                    country = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<Place> places;
        public ObservableCollection<Place> Places
        {
            get
            {
                return places;
            }
            set
            {
                if (places != value)
                {
                    places = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand SearchCommand { get; private set; }

        public PostalCodeSearchViewModel()
        {
            SearchCommand = new Command(SearchCommandExecute, SearchCommandCanExecute);
        }

        private bool SearchCommandCanExecute(object parameter)
        {
            bool canExecute = (!string.IsNullOrEmpty(City) &&
                !string.IsNullOrEmpty(Province) &&
                !string.IsNullOrEmpty(Country));

            return canExecute;
        }

        private async void SearchCommandExecute(object parameter)
        {
            try
            {
                var postalCodeService = new PostalCodeService();
                var queryResult = await postalCodeService.CityQueryAsync(Country, Province, City);
                this.Places = new ObservableCollection<Place>(queryResult.Places);
            }
            catch
            {
                if (ErrorOccurred != null)
                {
                    ErrorOccurred(this, null);
                }
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                ((Command)SearchCommand).ChangeCanExecute();
            }
        }
        #endregion
    }
}
