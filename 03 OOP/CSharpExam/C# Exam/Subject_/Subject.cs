using C__Exam.Exam_;

namespace C__Exam.Subject_
{
    internal class Subject
    {

        #region Properties
        public Exam exam { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        #endregion
        #region Constructors
        public Subject(Exam exam, int ID, string name)
        {
            this.exam = exam;
            this.ID = ID;
            Name = name;
        }
        public Subject(int ID, string name) //Exam couldn't be null here because of the CreateExam method
        {
            CreateExam();
            this.ID = ID;
            Name = name;
        }
        #endregion

        #region Methods
        public void CreateExam()
        {
            EExamType TheExamType = 0;
            do
            {

                Console.WriteLine($"Please Enter the Type of Exam (Final, Practical)");
                string? type = Console.ReadLine();
                Enum.TryParse<EExamType>(type, true, out TheExamType);
            }
            while (TheExamType == 0);

            exam = TheExamType switch //impossible to be none here because of the do while loop
            {
                EExamType.Final => new Exam_Final(),
                EExamType.Practical => new Exam_Practical()
            };

        }

        #endregion
    }
}
