using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using TriviaXamarinApp.Services;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using System.ComponentModel;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class EntryPageVM : BaseVM
    {
        #region Properties
        private string password { get; set; }
        public string Password
        { get { return this.password; }
            set 
            {
                this.password = value;
                this.OnPropertyChanged("Password");
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

        private string errorCode { get; set; }
        public string ErrorCode
        {
            get { return this.errorCode; }
            set
            {
                this.errorCode = value;
                this.OnPropertyChanged("ErrorCode");
            }
        }

        #endregion

        public EntryPageVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;            
        }

        public ICommand SignInCommand => new Command(SignInUser);                
        private async void SignInUser()
        {
            try
            {
                User loggingUser = new User();
                loggingUser = await this.DTP.API.LoginAsync(this.Email, this.Password);
                if (loggingUser == null)
                {
                    ErrorCode = "Could not log in. Please try again.";
                }
                else
                {
                    this.DTP.currentUser = loggingUser;
                    ErrorCode = "";
                    MenuPage menuPagePush = new MenuPage();
                    App.Current.MainPage.Navigation.PushAsync(menuPagePush);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ICommand PlayGameCommand => new Command(PlayGameUnlogged);
        private void PlayGameUnlogged()
        {
            QuestionsPage qp = new QuestionsPage();
            App.Current.MainPage.Navigation.PushAsync(qp);
        }
    }
}
