using C__Exam.Answer_;

namespace C__Exam.Question_
{
    internal class Question_TrueFalse : Question
    {
        #region Constructors
        // read all from the user
        public Question_TrueFalse() : base()
        {
            Body = new Answer[2];
            Body[0] = new Answer('a', "true");
            Body[1] = new Answer('b', "false");

            char rightAnswer;
            do
            {
                Console.WriteLine("please enter Right Answer ID (a:True, b:False) ");
                char.TryParse(Console.ReadLine(), out rightAnswer);
                rightAnswer = char.ToLower(rightAnswer);
            }
            while (rightAnswer != 'a' && rightAnswer != 'b');
            AnswerList[0] = Body[rightAnswer - 'a'];
        }
        public Question_TrueFalse(string header, float mark, Answer rightAnswer) : base(header, mark, rightAnswer)
        {
            Body = new Answer[2];
            Body[0] = new Answer('a', "true");
            Body[1] = new Answer('b', "false");

        }

        #endregion

        #region Methods
        public override void ShowQuestion()
        {
            Console.WriteLine(Header);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(Body[i]);
            }
        }
        #endregion
    }
}
