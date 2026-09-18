using Exam_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Questions
{
    public abstract class Question : IQuestion, IComparable<Question>, ICloneable
    {
        public string Header { get; private set; }
        public string Body { get; private set; }
        public int Mark { get; private set; }
        public Answer[] AnswerList { get; protected set; }
        public Answer? RightAnswer { get; protected set; }

        protected Question(string _header, string _body, int _mark)
        {
            if (string.IsNullOrWhiteSpace(_header) == true)
                throw new ArgumentException("Question header cannot be empty.");

            if (string.IsNullOrWhiteSpace(_body) == true)
                throw new ArgumentException("Question body cannot be empty.");

            if (_mark <= 0)
                throw new ArgumentException("Question mark must be greater than 0.");

            Header = _header;
            Body = _body;
            Mark = _mark;
            AnswerList = Array.Empty<Answer>();
        }

        public abstract void ShowQuestion();

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }


        public virtual object Clone()
        {
            Question clonedQuestion = (Question)this.MemberwiseClone();

            clonedQuestion.AnswerList = new Answer[AnswerList.Length];

            for (int i = 0; i < AnswerList.Length; i++)
            {
                clonedQuestion.AnswerList[i] = (Answer)AnswerList[i].Clone();

                if (RightAnswer != null && AnswerList[i].AnswerId == RightAnswer.AnswerId)
                {
                    clonedQuestion.RightAnswer = clonedQuestion.AnswerList[i];
                }
            }

            return clonedQuestion;
        }

        public override string ToString()
        {
            return $"{Header}:\t Mark {Mark}";
        }
    }
}
