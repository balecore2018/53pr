namespace ReportGeneration_Шаповалов.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group()
        {
            Name = string.Empty;
        }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
