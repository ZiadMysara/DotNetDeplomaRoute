using C__Exam.Answer_;

namespace C__Exam.Question_
{
    internal class Question_MCQ : Question
    {
        #region Properties
        public override Answer[] Body
        {
            set
            {
                if (value.Length == 4)
                {
                    base.Body = value;
                }
            }
        }

        #endregion
        #region Constructors

        // read all from the user
        public Question_MCQ() : base()
        {
            string? Tm;
            Body = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.WriteLine("please enter Question Body ");
                    Console.Write($"{(char)('a' + i)}) ");

                    Tm = Console.ReadLine();
                }
                while (Tm is null || Tm == "" || Body.Contains(new Answer((char)('a' + i), Tm), new AnswerCompareByName()));
                Body[i] = new Answer((char)('a' + i), Tm);
            }
            char rightAnswer;
            do
            {
                Console.WriteLine("please enter Right Answer ID (a, b, c, d)");
                char.TryParse(Console.ReadLine(), out rightAnswer);
                rightAnswer = char.ToLower(rightAnswer);
            }
            while (rightAnswer < 'a' || rightAnswer > 'd');
            AnswerList[0] = Body[rightAnswer - 'a'];
            Console.Clear();
        }

        public Question_MCQ(string header, Answer[] body, float mark, Answer rightAnswer) : base(header, mark, rightAnswer)
        {
            if (body?.Length != 4)
            {
                string? Tm;
                body = new Answer[4];
                for (int i = 0; i < 4; i++)
                {

                    do
                    {
                        Console.WriteLine("please enter Question Body ");
                        Console.Write($"{(char)('a' + i)}) ");

                        Tm = Console.ReadLine();
                    }
                    while (Tm is null || Tm == "" || body.Contains(new Answer((char)('a' + i), Tm), new AnswerCompareByName()));
                    body[i] = new Answer((char)('a' + i), Tm);
                }

            }

            Body = body;
        }
        #endregion

        public override void ShowQuestion()
        {
            Console.WriteLine(Header);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Body[i]);
            }
        }
    }
}
