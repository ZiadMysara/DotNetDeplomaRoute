using C__Exam.Answer_;

namespace C__Exam.Question_
{
    internal abstract class Question
    {

        #region Properties
        public string Header { get; set; }
        public virtual Answer[] Body { get; set; }
        public float Mark { get; set; }
        public Answer[] AnswerList { get; } // Must be 2 {Right Answer, Submited Answer}
        #endregion

        #region Constructors
        // Body coudn't be null as it initializes in all child constructors
        protected Question(string header, float mark, Answer rightAnswer)
        {
            Header = header;
            Mark = mark;
            AnswerList = new Answer[2];
            AnswerList[0] = rightAnswer;
        }

        // read all from the user
        protected Question() // Body coudn't be null as it initializes in all child constructors
        {
            AnswerList = new Answer[2];
            string? Tm;
            bool isCorrect = false;
            float mark;
            do
            {
                Console.WriteLine("please enter Question Header ");
                Tm = Console.ReadLine();
            }
            while (Tm is null || Tm == "");
            Header = Tm;
            do
            {
                Console.WriteLine("please enter Question Mark ");

                isCorrect = float.TryParse(Console.ReadLine(), out mark);
            }
            while (!isCorrect || mark < 0);
            Mark = mark;

        }

        #endregion

        #region Methods
        public abstract void ShowQuestion();

        public Answer? GetAnswerByID(char ID)
        {
            foreach (Answer answer in Body)
            {
                if (answer.ID == ID)
                {
                    return answer;
                }
            }
            return null;
        }

        public bool IsAnswerCorrect()
        {
            if (AnswerList?.Length == 2)
            {
                return AnswerList[0].Equals(AnswerList[1]);
            }
            return false;
        }
        #endregion

    }
}
