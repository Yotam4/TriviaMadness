using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModels;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        DataPageTransfer DTP;
        public EntryPage()
        {
            
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            EntryPageVM entryPageVM = new EntryPageVM(this.DTP);
            this.BindingContext = entryPageVM;
            InitializeComponent();

            StackLayout st = EntryStack;

        }

        private void GoToSignUp(object sender, EventArgs e)
        {
            Page SignUpPage = new SignUpPage();
            this.Navigation.PushAsync(SignUpPage);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.DTP.currentUser = null;
        }
    }
}