using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Views;


namespace TriviaXamarinApp.ViewModels
{
    class QuestionsListVM :BaseVM
    {
        public ObservableCollection<AmericanQuestion> questionsCollection { get; set; }
        public bool deleted { get; set; }
        public QuestionsListVM()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.deleted = false;
            this.questionsCollection = new ObservableCollection<AmericanQuestion>();
            SetQuestionsInCollection();
        }

        public void SetQuestionsInCollection()
        {
            this.questionsCollection.Clear();
            this.deleted = true;
            foreach (AmericanQuestion q in this.DTP.currentUser.Questions)
            {
                this.questionsCollection.Add(q);
            }
        }
        public ICommand EditQuestionCommand => new Command<AmericanQuestion>(EditQuestion);
        private void EditQuestion(AmericanQuestion editQuestion)
        {
            this.DTP.questionAdded = false;
            this.DTP.chosenQuestion = editQuestion;
            DeleteQuestion(this.DTP.chosenQuestion);
            if (deleted)
            {
                AddQuestionPage aqp = new AddQuestionPage();
                App.Current.MainPage.Navigation.PushAsync(aqp);                
                SetQuestionsInCollection();
            }
            else //Inform player that edit did not work.
            {

            }
            this.DTP.chosenQuestion = null; //removes the old selected question for good.
        }

        public ICommand DeleteQuestionCommand => new Command<AmericanQuestion>(DeleteQuestion);
        private async void DeleteQuestion(AmericanQuestion ques)
        {
            try
            {
                this.deleted = await this.DTP.API.DeleteQuestion(ques);
                if (this.deleted)
                {
                    this.DTP.currentUser.Questions.Remove(ques);
                    SetQuestionsInCollection();
                    deleted = true;
                }
                else
                {

                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
