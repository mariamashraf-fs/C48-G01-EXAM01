using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Questions
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string _body, int _mark, int _rightAnswerId) : base("True/False Question", _body, _mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

            foreach (Answer answer in AnswerList)
            {
                if (answer.AnswerId == _rightAnswerId)
                {
                    RightAnswer = answer;
                    break;
                }
            }

            if (RightAnswer == null)
            {
                throw new ArgumentException("The right answer ID for True/False questions must be 1 or 2.");
            }
        }

        public override void ShowQuestion()
        {
            Console.WriteLine(this.ToString());

            foreach (Answer answer in AnswerList)
            {
                Console.WriteLine(answer.ToString());
            }
        }
    }

}
