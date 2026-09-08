namespace ReportGeneration_Шаповалов.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int WorkId { get; set; }
        public string Value { get; set; }
        public string Lateness { get; set; }

        public Evaluation()
        {
            Value = string.Empty;
            Lateness = string.Empty;
        }

        public Evaluation(int id, int studentId, int workId, string value, string lateness)
        {
            Id = id;
            StudentId = studentId;
            WorkId = workId;
            Value = value;
            Lateness = lateness;
        }
    }
}
