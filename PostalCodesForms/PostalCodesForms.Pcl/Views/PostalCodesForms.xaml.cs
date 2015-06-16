using PostalCodesForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PostalCodesForms.Views
{
    public partial class PostalCodesForms : ContentPage
    {
        private PostalCodeSearchViewModel vm;
        public PostalCodesForms()
        {
            InitializeComponent();
            vm = new PostalCodeSearchViewModel();
            vm.ErrorOccurred += vm_ErrorOccurred;
            BindingContext = vm;

        }

        void vm_ErrorOccurred(object sender, EventArgs e)
        {
            DisplayAlert("Search failed", "Unknown error occurred. No data for you.", "ok");
        }
    }
}
