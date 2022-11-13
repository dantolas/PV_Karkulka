using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Question
    {
        public string question;
        public string rightAnswer;
        public List<String> answers;



        public Question(string question, string rightAnswer, string[] answers)
        {
            this.question = question;
            this.rightAnswer = rightAnswer;
            this.answers = answers.ToList();
        }

        public Question(string question, string rightAnswer)
        {
            this.question = question;
            this.rightAnswer = rightAnswer;
            this.answers = new List<String>();
        }
        public bool checkAnswer(string input)
        {
            return input.Equals(rightAnswer,StringComparison.OrdinalIgnoreCase);
        }


        public override string ToString()
        {
            string answerss = "";
            if (answers.Count > 0) answerss += "(Answer a,b,c etc.)\n";
            foreach(String s in answers) { answerss+= s+" "; }
            return "Question: "+question+"\n"+answerss;
        }

    }
}
