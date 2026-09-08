using System.Windows.Controls;
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
        }
    }
}
