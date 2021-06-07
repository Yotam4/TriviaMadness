 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Shapes;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Services;
using System.Windows.Input;
using System.ComponentModel;
using TriviaXamarinApp.Views;
namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsListPage : ContentPage
    {
        DataPageTransfer DTP;
        public QuestionsListPage()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = new QuestionsListVM();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}