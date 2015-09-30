using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NativeLocalizationDemo.WP8.Resources;
using System.Globalization;
using System.Threading;
using XamarinResxDemo.PCL;

namespace NativeLocalizationDemo.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        MainViewModel _viewModel;
        int keydownCount = 0;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var ci = System.Threading.Thread.CurrentThread.CurrentUICulture;
            _viewModel.LoadTranslations(ci);
        }

    }
}