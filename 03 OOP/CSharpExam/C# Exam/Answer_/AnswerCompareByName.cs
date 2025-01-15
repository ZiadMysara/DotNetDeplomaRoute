namespace C__Exam.Answer_
{
    internal class AnswerCompareByName : IEqualityComparer<Answer>
    {
        public bool Equals(Answer? x, Answer? y)
        {
            if (x is null || y is null)
            {
                return false;
            }
            return x.Text == y.Text;
        }
        public int GetHashCode(Answer obj)
        {
            return obj.Text.GetHashCode();
        }

    }
}
