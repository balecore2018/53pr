namespace ReportGeneration_Шаповалов.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }

        public Discipline()
        {
            Name = string.Empty;
        }

        public Discipline(int id, int groupId, string name)
        {
            Id = id;
            GroupId = groupId;
            Name = name;
        }
    }
}
