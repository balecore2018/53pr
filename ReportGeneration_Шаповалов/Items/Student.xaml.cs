using System.Windows.Controls;
using ReportGeneration_Шаповалов.Classes;
using StudentModel = ReportGeneration_Шаповалов.Models.Student;

namespace ReportGeneration_Шаповалов.Items
{
    public partial class Student : UserControl
    {
        public StudentModel CurrentStudent { get; }

        public Student(StudentModel student)
        {
            InitializeComponent();
            CurrentStudent = student;
            DataContext = CurrentStudent;

            string groupName = new GroupContext()
                .AllGroups()
                .FirstOrDefault(group => group.Id == CurrentStudent.GroupId)
                ?.Name ?? "Группа не указана";

            FullNameText.Text = CurrentStudent.FullName;
            GroupText.Text = groupName;
        }
    }
}
