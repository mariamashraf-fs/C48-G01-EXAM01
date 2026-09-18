using Exam_1.Classes.Questions;
using Exam_1.Classes.Subjects;
using Exam_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Exams
{
    public abstract class Exam : IExam, IComparable<Exam>, ICloneable
    {
        public int ExamTime { get; private set; }
        public int NumberOfQuestions { get; private set; }
        public Question[] Questions { get; protected set; }
        public Subject Subject { get; private set; }


        protected Exam(int _examTime, int _numberOfQuestions, Question[] _questions, Subject _subject)
        {
            if (_examTime < 30 || _examTime > 180)
            {
                throw new ArgumentException("Exam time must be between 30 and 180 minutes.");
            }

            if (_numberOfQuestions <= 0)
            {
                throw new ArgumentException("Number of questions must be greater than 0.");
            }

            if (_questions == null || _questions.Length != _numberOfQuestions)
            {
                throw new ArgumentException("Questions length must match the number of questions.");
            }
            if (_subject == null)
            {
                throw new ArgumentNullException(nameof(_subject));
            }

            ExamTime = _examTime;
            NumberOfQuestions = _numberOfQuestions;
            Questions = _questions;
            Subject = _subject;
        }

        public abstract void ShowExam();

        public int CompareTo(Exam? other)
        {
            if (other == null)
            {
                return 1;
            }

            return ExamTime.CompareTo(other.ExamTime);
        }


        public virtual object Clone()
        {
            Exam clonedExam = (Exam)MemberwiseClone();

            clonedExam.Questions = new Question[Questions.Length];

            for (int i = 0; i < Questions.Length; i++)
            {
                clonedExam.Questions[i] = (Question)Questions[i].Clone();
            }

            return clonedExam;
        }

        internal void SetSubject(Subject subject)
        {
            Subject = subject;
        }


        public override string ToString()
        {
            return $"Exam Time: {ExamTime} min | Number Of Questions: {NumberOfQuestions}";
        }

    }
}
