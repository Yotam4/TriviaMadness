using System;
using System.Collections.Generic;
using System.Text;

namespace TriviaXamarinApp.Models
{
    public class AmericanQuestion
    {
        public string QText { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] OtherAnswers { get; set; }
        public string CreatorNickName { get; set; }

        public AmericanQuestion()
        {

        }

        public void CreateQuestion()
        {
            this.QText = "Banana? What color";
            this.CorrectAnswer = "Yellow";
            this.OtherAnswers = new string[3];
            this.OtherAnswers[0] = "Green";
            this.OtherAnswers[1] = "Blue";
            this.OtherAnswers[2] = "Purple";
            this.CreatorNickName = "Yotam";

        }

    }
}
