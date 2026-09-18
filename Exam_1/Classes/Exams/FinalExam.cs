using Exam_1.Classes.Questions;
using Exam_1.Classes.Subjects;
using System.Diagnostics;
using System;

namespace Exam_1.Classes.Exams
{
    public class FinalExam : Exam
    {
        public FinalExam(int _examTime, int _numberOfQuestions, Question[] _questions, Subject _subject)
            : base(_examTime, _numberOfQuestions, _questions, _subject) { }

        public override void ShowExam()
        {
            Answer[] studentAnswers = new Answer[NumberOfQuestions];
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("                 Final Exam                  ");
                Console.WriteLine("=============================================\n");

                Question question = Questions[i];

                Console.WriteLine($"Question {i + 1}: {question.Body}");
                question.ShowQuestion();

                int studentAnswerId;
                bool isValidChoice;

                do
                {
                    Console.Write("Enter your answer ID: ");
                    isValidChoice = int.TryParse(Console.ReadLine(), out studentAnswerId);

                    if (isValidChoice == true)
                    {
                        isValidChoice = false;

                        foreach (Answer answer in question.AnswerList)
                        {
                            if (answer.AnswerId == studentAnswerId)
                            {
                                studentAnswers[i] = answer;
                                isValidChoice = true;
                                break;
                            }
                        }
                    }

                    if (isValidChoice == false)
                    {
                        Console.WriteLine("Invalid choice, please enter a valid answer ID.");
                    }
                }
                while (isValidChoice == false);
            }

            stopwatch.Stop();
            Console.Clear();

            int totalMark = 0;
            int studentGrade = 0;

            Console.WriteLine("=============================================");
            Console.WriteLine("             Final Exam Results              ");
            Console.WriteLine("=============================================\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                Question question = Questions[i];
                totalMark += question.Mark;

                Console.WriteLine($"Question {i + 1}: {question.Body}");
                Console.WriteLine($"Your Answer => {studentAnswers[i].AnswerText}");
                Console.WriteLine($"Correct Answer => {question.RightAnswer!.AnswerText}");

                if (studentAnswers[i].AnswerId == question.RightAnswer!.AnswerId)
                {
                    studentGrade += question.Mark;
                }

                Console.WriteLine("---------------------------------------------");
            }

            Console.WriteLine($"\nYour Grade is: {studentGrade} out of {totalMark}");
            Console.WriteLine($"Time Taken     : {stopwatch.Elapsed}");
            Console.WriteLine("\nThank you for completing the exam. Best of luck!");
            Console.WriteLine("=============================================");
        }
    }
}