using C__Exam.Answer_;
using C__Exam.Question_;

namespace C__Exam.Exam_
{
    internal abstract class Exam
    {
        #region Properties
        public Question[] Questions { get; set; }
        public int Time { get; set; }
        public int NumOfQuestions { get; set; }
        #endregion

        #region Constructors
        protected Exam() //Questions coudn't be null as it initializes in all child constructors
        {
            bool isCorrect = false;
            int time;

            do
            {
                Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min))");
                isCorrect = int.TryParse(Console.ReadLine(), out time);
            }
            while (time < 30 || time > 180 || !isCorrect);


            int numOfQuestions;
            do
            {
                Console.WriteLine("Please Enter the Number of Questions For Exam");
                isCorrect = int.TryParse(Console.ReadLine(), out numOfQuestions);
            }
            while (numOfQuestions < 1 || !isCorrect);


            this.Time = time;
            this.NumOfQuestions = numOfQuestions;
        }
        protected Exam(int numOfQuestions, Question[] questions, int time)
        {
            NumOfQuestions = numOfQuestions;
            Questions = questions;
            Time = time;
        }
        #endregion

        #region Methods
        public abstract void ShowExam();
        public void ShowExamQuestions()
        {
            bool isCorrect = false;
            for (int i = 0; i < NumOfQuestions; i++)
            {
                char answerID;
                Console.WriteLine($"Mark: {Questions[i].Mark}");
                Questions[i].ShowQuestion();
                if (Questions[i].GetType() == typeof(Question_TrueFalse))
                {
                    do
                    {
                        Console.WriteLine("Please chose correct answer ID (a:True, b:False)");
                        isCorrect = char.TryParse(Console.ReadLine(), out answerID);
                        answerID = char.ToLower(answerID);
                    }
                    while (!isCorrect || (answerID != 'a' && answerID != 'b'));
                    Answer answer = Questions[i].GetAnswerByID(answerID)!;//Couldn't be null as brevious Conditions
                    Questions[i].AnswerList[1] = answer!;
                    Console.WriteLine();
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Please chose correct answer ID (a, b, c, d)");
                        isCorrect = char.TryParse(Console.ReadLine(), out answerID);
                        answerID = char.ToLower(answerID);
                    }
                    while (!isCorrect || (answerID != 'a' && answerID != 'b' && answerID != 'c' && answerID != 'd'));
                    Answer answer = Questions[i].GetAnswerByID(answerID)!;//Could be null as brevious Conditions
                    Questions[i].AnswerList[1] = answer!;
                    Console.WriteLine();
                }
            }
        }
        public abstract void ShowAfterExamEnd();


        public float CalculateGrade()
        {
            float totalGrade = 0;
            foreach (Question question in Questions)
            {
                if (question.IsAnswerCorrect())
                {
                    totalGrade += question.Mark;
                }
            }
            return totalGrade;
        }
        #endregion
    }
}
