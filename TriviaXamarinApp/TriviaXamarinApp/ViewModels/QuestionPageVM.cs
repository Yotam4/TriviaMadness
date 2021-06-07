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
    class QuestionPageVM : BaseVM        
    {
        #region AnswersProperty

        public ObservableCollection<string> AnswersCollection { get; set; }

        private string questionText { get; set; }
        public string QuestionText
        {
            get { return this.questionText; }
            set
            {
                this.questionText = value;
                this.OnPropertyChanged("QuestionText");
            }
        }

        private string questionAuthor { get; set; }
        public string QuestionAuthor
        {
            get { return this.questionAuthor; }
            set
            {
                this.questionAuthor = value;
                this.OnPropertyChanged("QuestionAuthor");
            }
        }
        private int points { get; set; }
        public int Points
        {
            get { return this.points; }
            set
            {
                this.points = value;
                this.OnPropertyChanged("Points");
            }
        }

        private string addQuesColor { get; set; }
        public string AddQuesColor
        {
            get { return this.addQuesColor; }
            set
            {
                this.addQuesColor = value;
                this.OnPropertyChanged("AddQuesColor");
            }
        }
        private string questionColor { get; set; }
        public string QuestionColor
        {
            get { return this.questionColor; }
            set
            {
                this.questionColor = value;
                this.OnPropertyChanged("QuestionColor");
            }
        }
        #endregion


        public AmericanQuestion CurrentQuestion { get; set; }


        public QuestionPageVM()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.AnswersCollection = new ObservableCollection<string>();
            if(this.DTP.currentUser != null)
                this.QuestionText = "Press the button for a question";
            else
                this.QuestionText = "Press the button for a question\n Sign up to add questions"; 
            this.AddQuesColor = "LightGray";
            this.QuestionColor = "Black";
        }
        public ICommand UserAnswerCommand => new Command<string>(UserAnswer);

        private void UserAnswer(string answer)
        {
            if (this.CurrentQuestion.CorrectAnswer == answer)
            {
                this.Points = this.Points + 1;
                this.QuestionText = "You are Correct!\n" + "Your Answer was: " + this.CurrentQuestion.CorrectAnswer;
                this.QuestionColor = "ForestGreen";
            }
            else
            {
                this.QuestionText = "You are Wrong. \nYour Answer was: " + answer + "\nThe correct answer was: " + this.CurrentQuestion.CorrectAnswer;
                this.QuestionColor = "Red";
            }
            if(this.Points >= 3 && this.DTP.currentUser != null)
            {
                this.AddQuesColor = "PaleGoldenrod";
            }
            this.QuestionAuthor = "";
            this.AnswersCollection.Clear();
        }

        public ICommand NextQuestionCommand => new Command(SetNextQuestion);
        private async void SetNextQuestion() //Gets and sets a new question in the VM then sets it's answers for the collection.
        {
            this.CurrentQuestion = await this.DTP.API.GetRandomQuestion();
            this.QuestionAuthor = "Question by: " + this.CurrentQuestion.CreatorNickName;
            this.QuestionColor = "Black";

            SetAnswersQuestions();

        }
        public void SetAnswersQuestions() //Uses the current question and sets the new answers.
        {
            this.AnswersCollection.Clear();
            this.QuestionText = this.CurrentQuestion.QText;

            bool insert = false;
            Random ran = new Random();
            string[] answers = new string[4];
            answers[ran.Next(0, 4)] = this.CurrentQuestion.CorrectAnswer;

            int answerNum = 0;
            for (int i = 0; i < 4; i++)
            {
                    if (answers[i] != this.CurrentQuestion.CorrectAnswer)
                        insert = true;

                if (insert)
                {
                    answers[i] = this.CurrentQuestion.OtherAnswers[answerNum++];
                    insert = false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                this.AnswersCollection.Add(answers[i]);
            }
        }

        public ICommand AddQuestionCommand => new Command(AddQuestion);
        private void AddQuestion() //Gets and sets a new question in the VM then sets it's answers for the collection.
        {
            if (this.DTP.currentUser != null)
            {
                if (this.Points < 3)
                    return;
                this.Points -= 3;
                if (this.Points < 3)
                    this.AddQuesColor = "LightGray";
                AddQuestionPage addQuestionPage = new AddQuestionPage();
                App.Current.MainPage.Navigation.PushAsync(addQuestionPage);
            }
        }
    }
}
