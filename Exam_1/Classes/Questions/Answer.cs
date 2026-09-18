using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Questions
{
    public class Answer : ICloneable
    {
        public int AnswerId { get; private set; }
        public string AnswerText { get; private set; }

        public Answer(int _answerid, string _answertext)
        {
            if (_answerid <= 0)
                throw new ArgumentException("Answer ID must be greater than 0.");

            if (string.IsNullOrWhiteSpace(_answertext) == true)
                throw new ArgumentException("Answer text cannot be empty.");

            AnswerId = _answerid;
            AnswerText = _answertext;
        }

        public override string ToString()
        {
            return $"{AnswerId}- {AnswerText}";
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }
    }
}
