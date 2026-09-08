namespace ReportGeneration_Шаповалов.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Discipline()
        {
            Name = string.Empty;
        }

        public Discipline(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
