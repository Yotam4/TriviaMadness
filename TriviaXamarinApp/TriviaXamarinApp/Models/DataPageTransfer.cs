using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;

namespace TriviaXamarinApp.Models
{
    class DataPageTransfer
    {
       public User currentUser { get; set; }
       public TriviaWebAPIProxy API { get; private set; }
       public AmericanQuestion chosenQuestion { get; set; }
        public bool questionAdded { get; set; }
        
        public DataPageTransfer()
        {
            this.API = TriviaWebAPIProxy.CreateProxy();
            this.questionAdded = false;
        }
    }
}
