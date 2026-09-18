using Exam_1.Classes.Questions;
using Exam_1.Enums;
using System;

namespace Exam_1.Classes.Helpers
{
    public static class QuestionHelper
    {
        public static Question[] CreateQuestionsList(int _numberOfQuestions, ExamType _examType)
        {
            Question[] questions = new Question[_numberOfQuestions];

            for (int i = 0; i < _numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter details for question {i + 1}:");

                questions[i] = CreateSingleQuestion(_examType);
            }

            return questions;
        }

        private static Question CreateSingleQuestion(ExamType _examType)
        {
            QuestionType questionType = QuestionType.MCQ;

            if (_examType == ExamType.Final)
            {
                questionType = (QuestionType)InputHelper.GetValidInput("Choose question type: 1 for MCQ, 2 for True/False:",1,2);
            }

            string body = InputHelper.ReadNonEmptyText("Please enter the question body:");
            int mark = InputHelper.GetValidInput("Please enter the question mark:", 1, 100);

            if (questionType == QuestionType.MCQ)
            {
                return CreateMCQQuestion(body, mark);
            }
            else
            {
                return CreateTrueFalseQuestion(body, mark);
            }
        }

        private static MCQQuestion CreateMCQQuestion(string _body, int _mark)
        {
            Console.WriteLine("Choices of Question:");
            Answer[] answers = new Answer[4];

            for (int j = 0; j < 4; j++)
            {
                string choiceText = InputHelper.ReadNonEmptyText($"Please enter choice number {j + 1}:");
                answers[j] = new Answer(j + 1, choiceText);
            }

            int rightAnswerId = InputHelper.GetValidInput("Please enter the ID of the correct answer (1 to 4):", 1, 4);

            return new MCQQuestion(_body, _mark, answers, rightAnswerId);
        }

        private static TrueFalseQuestion CreateTrueFalseQuestion(string _body, int _mark)
        {
            int rightAnswerId = InputHelper.GetValidInput("Please enter the ID of the correct answer (1 for True, 2 for False):", 1, 2);

            return new TrueFalseQuestion(_body, _mark, rightAnswerId);
        }
    }
}