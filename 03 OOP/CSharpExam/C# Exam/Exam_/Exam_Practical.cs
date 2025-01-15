using C__Exam.Question_;

namespace C__Exam.Exam_
{
    internal class Exam_Practical : Exam
    {
        #region Constructors
        // read all from the user
        public Exam_Practical() : base()
        {
            this.Questions = new Question_MCQ[this.NumOfQuestions];
            for (int i = 0; i < this.NumOfQuestions; i++)
            {
                Questions[i] = new Question_MCQ();
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

        // have only MCQ Questions
        public Exam_Practical(int NumOfQuestions, Question_MCQ[] questions, int time) : base(NumOfQuestions, questions, time)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("Practical Exam");

            Console.WriteLine("MCQ Questions");
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
            Console.WriteLine("Practical Exam Ended");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            //Show only the right answers 
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].ShowQuestion();
                Console.WriteLine($"Correct Answer: {Questions[i].AnswerList[0]}");
                Console.WriteLine("-------------------------------------------------");
            }

        }
        #endregion

    }
}
