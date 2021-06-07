using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Models;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        DataPageTransfer DTP;
        public MenuPage()
        {
            this.DTP = this.DTP = (DataPageTransfer)App.Current.BindingContext;
            InitializeComponent();
        }

        private void GoToGame(object sender, EventArgs e)
        {
            QuestionsPage qs = new QuestionsPage();

            Navigation.PushAsync(qs);
        }

        private void GoToQuestions(object sender, EventArgs e)
        {
            QuestionsListPage qls = new QuestionsListPage();
            Navigation.PushAsync(qls);
        }
    }
}