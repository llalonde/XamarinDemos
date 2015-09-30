using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinResxDemo.PCL;

namespace NativeLocalizationDemo.WP8
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        private string _applicationTitle;
        public string ApplicationTitle
        {
            get
            {
                return _applicationTitle;
            }
            set
            {
                _applicationTitle = value;
                RaisePropertyChanged();
            }
        }

        private string _hello;
        public string Hello
        {
            get
            {
                return _hello;
            }
            set
            {
                _hello = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Public Methods

        public void LoadTranslations(CultureInfo ci)
        {
            ApplicationTitle = TranslationHelper.GetString("ApplicationTitle", ci);
            Hello = TranslationHelper.GetString("Hello", ci);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
