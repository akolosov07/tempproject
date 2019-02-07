namespace Temp.Repository.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
