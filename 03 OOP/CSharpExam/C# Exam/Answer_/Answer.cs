namespace C__Exam.Answer_
{
    internal class Answer : IEquatable<Answer>
    {

        #region Properties
        public char ID { get; set; }
        public string Text { get; set; }
        #endregion
        #region Constructors
        public Answer(char ID, string text)
        {
            this.ID = ID;
            Text = text;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{ID}) {Text}";
        }

        public bool Equals(Answer? other)
        {
            return other != null && ID == other.ID && ID == other.ID;
        } 
        #endregion

    }
}
