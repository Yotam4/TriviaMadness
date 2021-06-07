using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddQuestionPage : ContentPage
    {
        DataPageTransfer DTP;
        public AddQuestionPage()
        {            
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            AddQuestionVM awv = new AddQuestionVM(this.DTP);

            if (this.DTP.chosenQuestion != null) //If player is editing, then it will recieve a question and input it already.
                awv.AddQuestion = this.DTP.chosenQuestion;

            this.BindingContext = awv;
            InitializeComponent();
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }
    }
}