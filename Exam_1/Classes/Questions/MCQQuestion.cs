using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Questions
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string _body, int _mark, Answer[] _answers, int rightAnswerId) : base("MCQ Question", _body, _mark)
        {
            if (_answers == null)
            {
                throw new ArgumentNullException(nameof(_answers));
            }

            if (_answers.Length != 4)
            {
                throw new ArgumentException("MCQ question must have exactly 4 choices.");
            }

            foreach (Answer answer in _answers)
            {
                if (answer == null)
                {
                    throw new ArgumentException("Choices cannot be null.");
                }
            }

            AnswerList = _answers;

            foreach (Answer answer in AnswerList)
            {
                if (answer.AnswerId == rightAnswerId)
                {
                    RightAnswer = answer;
                    break;
                }
            }

            if (RightAnswer == null)
            {
                throw new ArgumentException("The right answer ID does not match any of the provided choices.");
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
