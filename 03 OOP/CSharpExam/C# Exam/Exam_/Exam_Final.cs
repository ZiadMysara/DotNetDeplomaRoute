using C__Exam.Question_;

namespace C__Exam.Exam_
{
    internal class Exam_Final : Exam
    {
        #region Constructors
        // Read all attributes from the user
        public Exam_Final() : base()
        {

            this.Questions = new Question[this.NumOfQuestions];
            for (int i = 0; i < this.NumOfQuestions; i++)
            {
                EQuestionType TheQuestionType = 0;
                do
                {

                    Console.WriteLine($"Please Enter the Type of Questions {i + 1} For Exam (MCQ or TF)");
                    string? type = Console.ReadLine();
                    Enum.TryParse<EQuestionType>(type, true, out TheQuestionType);
                }
                while (TheQuestionType == 0);

                Questions[i] = TheQuestionType switch //impossible to be none here because of the do while loop
                {
                    EQuestionType.MCQ => new Question_MCQ(),
                    EQuestionType.TF => new Question_TrueFalse()
                };
            }
            char ChAnswer;
            bool isCorrect = false;
            do
            {
                Console.WriteLine("Are you need to show the exam(y/n)");
                isCorrect = char.TryParse(Console.ReadLine(), out ChAnswer);
                ChAnswer = char.ToLower(ChAnswer);
            }
            while (!isCorrect || (ChAnswer != 'y' && ChAnswer != 'n'));
            if (ChAnswer == 'y')
            {
                ShowExam();
            }

        }




        public Exam_Final(int numOfQuestions, Question[] questions, int time) : base(numOfQuestions, questions, time)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("Final Exam");
            if (typeof(Question_MCQ) == Questions[0].GetType())
            {
                Console.WriteLine("MCQ Questions");
            }
            else
            {
                Console.WriteLine("TF Questions");
            }
            DateTime t = DateTime.Now.AddMinutes(Time);
            Console.WriteLine($"Date: {DateTime.Now.ToShortDateString()} ");
            Console.WriteLine($"Time: start From {DateTime.Now.ToShortTimeString()} to {t.ToShortTimeString()}");
            Console.WriteLine($"Number of Questions: {NumOfQuestions}");
            Console.WriteLine("-------------------------------------------------");
            ShowExamQuestions();
            ShowAfterExamEnd();
        }
        public override void ShowAfterExamEnd()
        {
            Console.Clear();
            Console.WriteLine("Final Exam Ended");
            Console.WriteLine("----------------");
            Console.WriteLine();
            //Array.ForEach(Questions, question => question.ShowQuestion());
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Mark: {Questions[i].Mark}");
                Questions[i].ShowQuestion();
                Console.WriteLine($"Your Answer: {Questions[i].AnswerList[1]}");
                Console.WriteLine($"Correct Answer: {Questions[i].AnswerList[0]}");
                Console.WriteLine("-------------------------------------------------");

            }
            Console.WriteLine("Your Grade is: " + CalculateGrade());
        }

        #endregion
    }
}
