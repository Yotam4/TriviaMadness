using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;
namespace TriviaXamarinApp.ViewModels
{
    class SignUpVM :BaseVM
    {
        #region Properties
        private string nickname { get; set; }
        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                this.nickname = value;
                this.OnPropertyChanged("Nickname");
            }
        }
        private string email { get; set; }
        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.OnPropertyChanged("Email");
            }
        }
        private string password { get; set; }
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.OnPropertyChanged("Password");
            }
        }
        private string statusText { get; set; }
        public string StatusText
        {
            get { return this.statusText; }
            set
            {
                this.statusText = value;
                this.OnPropertyChanged("StatusText");
            }
        }
        #endregion


        public SignUpVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;
            this.statusText = "Enter your credentials:";
        }

        public ICommand SignUpCommand => new Command(SignUserUp);
        public async void SignUserUp()
        {
            try
            {
                User newUser = new User(this.Email, this.Nickname, this.Password);
                bool success = await this.DTP.API.RegisterUser(newUser);
                if (success)
                {
                    Nickname = "Sign Up Successfull";
                    this.DTP.currentUser = newUser;
                    MenuPage menuPagePush = new MenuPage();
                    App.Current.MainPage.Navigation.PushAsync(menuPagePush);                    
                }
                else
                    this.statusText = "Sign Up Failed, please try again";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
