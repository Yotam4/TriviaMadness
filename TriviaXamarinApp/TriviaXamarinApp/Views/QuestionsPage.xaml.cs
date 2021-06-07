using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;


namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsPage : ContentPage
    {
        DataPageTransfer DTP;
        QuestionPageVM pageVM;        
        public QuestionsPage() 
        {
            this.pageVM = new QuestionPageVM();
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = this.pageVM;

            InitializeComponent();
        }


    }
}