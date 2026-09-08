namespace ReportGeneration_Шаповалов.Models
{
    public class Work
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Work()
        {
            Name = string.Empty;
            Date = DateTime.Today;
        }

        public Work(int id, int disciplineId, string name, DateTime date)
        {
            Id = id;
            DisciplineId = disciplineId;
            Name = name;
            Date = date;
        }
    }
}
