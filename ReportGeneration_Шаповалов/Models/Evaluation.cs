namespace ReportGeneration_Шаповалов.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int WorkId { get; set; }
        public int Value { get; set; }
        public bool IsVisited { get; set; }

        public Evaluation()
        {
        }

        public Evaluation(int id, int studentId, int workId, int value, bool isVisited)
        {
            Id = id;
            StudentId = studentId;
            WorkId = workId;
            Value = value;
            IsVisited = isVisited;
        }
    }
}
