using Exam_1.Classes.Exams;
using Exam_1.Classes.Questions;
using Exam_1.Enums;
using System;

namespace Exam_1.Classes.Subjects
{
    public class Subject : IComparable<Subject>, ICloneable
    {
        public int SubjectId { get; private set; }
        public string SubjectName { get; private set; }
        public Exam? Exam { get; private set; }

        public Subject(int _subjectId, string _subjectName)
        {
            if (_subjectId <= 0)
                throw new ArgumentException("Subject ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(_subjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            SubjectId = _subjectId;
            SubjectName = _subjectName;
        }

        public Exam CreateExam(ExamType examType, int _examTime, int _numberOfQuestions, Question[] _questions)
        {
            if (examType == ExamType.Final)
            {
                Exam = new FinalExam(_examTime, _numberOfQuestions, _questions, this);
            }
            else if (examType == ExamType.Practical)
            {
                Exam = new PracticalExam(_examTime, _numberOfQuestions, _questions, this);
            }
            else
            {
                throw new ArgumentException("Invalid exam type.");
            }

            return Exam;
        }

        public void StartSubjectExam()
        {
            if (Exam == null)
            {
                Console.WriteLine($"No exam has been created yet for {SubjectName}.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"=============================================");
            Console.WriteLine($"      Welcome to the {SubjectName} Exam!     ");
            Console.WriteLine($"=============================================");

            Console.WriteLine($"Exam Details: {Exam}");

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Instructions:");
            Console.WriteLine("- Read each question carefully.");
            Console.WriteLine("- You cannot go back to previous questions.");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press any key when you are ready to begin...");

            Console.ReadKey();
            Exam.ShowExam();
        }

        public int CompareTo(Subject? other)
        {
            if (other == null) return 1;
            return SubjectId.CompareTo(other.SubjectId);
        }

        public object Clone()
        {
            Subject clonedSubject = (Subject)this.MemberwiseClone();

            if (this.Exam != null)
            {
                clonedSubject.Exam = (Exam)this.Exam.Clone();
                clonedSubject.Exam.SetSubject(clonedSubject);
            }

            return clonedSubject;
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId} | Subject Name: {SubjectName}";
        }
    }
}