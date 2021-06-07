using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;

namespace TriviaXamarinApp.ViewModels
{
    class AddQuestionVM : BaseVM
    {
        public bool hasAdded { get; set; }
        private AmericanQuestion addQuestion { get; set; }
        public AmericanQuestion AddQuestion
        {
            get { return this.addQuestion; }
            set
            {
                this.addQuestion = value;
                this.OnPropertyChanged("AddQuestion");
            }
        }
        private string statusCode { get; set; }
        public string StatusCode
        {
            get { return this.statusCode; }
            set
            {
                this.statusCode = value;
                this.OnPropertyChanged("StatusCode");
            }
        }
        public AddQuestionVM(DataPageTransfer dtp)
        {
            this.AddQuestion = new AmericanQuestion();
            this.DTP = dtp;
            this.StatusCode = "Add a new question:";
            hasAdded = false;
            this.AddQuestion.CreatorNickName = this.DTP.currentUser.NickName;
            this.AddQuestion.OtherAnswers = new string[3];
        }


        public ICommand AddQuestionCommand => new Command(AddQuestionToServer);
        private async void AddQuestionToServer()
        {
            if (this.AddQuestion.QText != null && this.AddQuestion.CreatorNickName != null && this.AddQuestion.OtherAnswers[0] != null && this.AddQuestion.OtherAnswers[1] != null && this.AddQuestion.OtherAnswers[2] != null)
            {
                try
                {

                    bool isAdded = await this.DTP.API.PostNewQuestion(this.addQuestion);
                    if (isAdded)
                    {
                        this.statusCode = "Success.";
                        hasAdded = true;
                        this.DTP.currentUser.Questions.Add(this.AddQuestion);
                        this.DTP.questionAdded = true;
                        App.Current.MainPage.Navigation.PopAsync(); //Not awaitable on purpose.
                    }
                    else
                    {
                        this.statusCode = "Operation did not work, please try again..";
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                this.statusCode = "You did not fill all the credentials, try again.";
            }
        }
    }
}
