using Exam_1.Classes.Exams;
using Exam_1.Classes.Questions;
using Exam_1.Classes.Subjects;
using Exam_1.Enums;
using System;

namespace Exam_1.Classes.Helpers
{
    public static class ExamHelper
    {
        public static void StartExam()
        {
            PrintWelcome();
            Subject subject = ReadSubjectInfo();
            (ExamType examType, int examTime, int numberOfQuestions, Question[] questions) = InitializeExam();
            subject.CreateExam(examType, examTime, numberOfQuestions, questions);
            ConfirmAndStart(subject);
        }


        private static void PrintWelcome()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("          Welcome to C# Exam System          ");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Let's prepare your exam step by step.\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }


        private static Subject ReadSubjectInfo()
        {
            int subjectId = InputHelper.GetValidInput("Please enter the Subject ID:", 1, 1000);
            string subjectName = InputHelper.ReadNonEmptyText("Please enter the Subject Name:");

            return new Subject(subjectId, subjectName);
        }

        private static (ExamType, int, int, Question[]) InitializeExam()
        {
            Console.Clear();
            int examTypeInput = InputHelper.GetValidInput("Enter the type of exam (1 for Practical, 2 for Final):", 1, 2);
            ExamType examType = (ExamType)examTypeInput;

            int examTime = InputHelper.GetValidInput("Please enter the time for the exam (30 to 180 minutes):", 30, 180);
            int numberOfQuestions = InputHelper.GetValidInput("Please enter the number of questions:", 1, 100);

            Question[] questions = QuestionHelper.CreateQuestionsList(numberOfQuestions, examType);

            return (examType, examTime, numberOfQuestions, questions);
        }

        private static void ConfirmAndStart(Subject subject)
        {
            Console.Clear();
            Console.WriteLine("Do You Want To Start Exam (Y | N) ?");

            string? startChoice;
            do
            {
                startChoice = Console.ReadLine()?.Trim().ToUpper();

                if (startChoice == "Y")
                {
                    Console.Clear();
                    subject.StartSubjectExam();
                }
                else if (startChoice == "N")
                {
                    Console.Clear();
                    Console.WriteLine("=============================================");
                    Console.WriteLine("     Exam cancelled. Thank you and goodbye!  ");
                    Console.WriteLine("=============================================");
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter exactly Y or N:");
                }

            } while (startChoice != "Y" && startChoice != "N");
        }
    }
}