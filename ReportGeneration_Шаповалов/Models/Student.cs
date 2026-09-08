namespace ReportGeneration_Шаповалов.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public bool Expelled { get; set; }

        public string FullName => $"{Surname} {Name} {Patronymic}".Trim();

        public Student()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
        }

        public Student(int id, int groupId, string surname, string name, string patronymic, bool expelled = false)
        {
            Id = id;
            GroupId = groupId;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Expelled = expelled;
        }
    }
}
