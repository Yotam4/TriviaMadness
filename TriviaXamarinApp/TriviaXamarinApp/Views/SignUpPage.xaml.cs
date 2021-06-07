using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        DataPageTransfer DTP;
        public SignUpPage()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = new SignUpVM(this.DTP);
            InitializeComponent();            
        }
    }
}