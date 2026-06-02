namespace PhysicsTesting.Models
{
    /// <summary>
    /// Модель вопроса для теста
    /// </summary>
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new();
        public int CorrectAnswerIndex { get; set; }
        public string Topic { get; set; } = string.Empty;

        public Question() { }

        public Question(int id, string text, List<string> answers, int correctAnswerIndex, string topic)
        {
            Id = id;
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
            Topic = topic;
        }
    }
}
