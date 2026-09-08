using System.Windows.Controls;
using EvaluationModel = ReportGeneration_Шаповалов.Models.Evaluation;
using StudentModel = ReportGeneration_Шаповалов.Models.Student;
using WorkModel = ReportGeneration_Шаповалов.Models.Work;

namespace ReportGeneration_Шаповалов.Items
{
    public partial class Student : UserControl
    {
        public StudentModel CurrentStudent { get; }

        public Student(StudentModel student, IEnumerable<WorkModel> works, IEnumerable<EvaluationModel> evaluations)
        {
            InitializeComponent();
            CurrentStudent = student;
            DataContext = CurrentStudent;

            List<WorkModel> workList = works.ToList();
            List<EvaluationModel> studentEvaluations = evaluations
                .Where(evaluation => evaluation.StudentId == CurrentStudent.Id)
                .ToList();

            FullNameText.Text = CurrentStudent.FullName;
            ExpelledCheck.IsChecked = CurrentStudent.Expelled;

            int completedCount = studentEvaluations.Count(evaluation => !string.IsNullOrWhiteSpace(evaluation.Value));
            int attendedCount = studentEvaluations.Count(evaluation => evaluation.Lateness != "90");

            WorksProgress.Value = Percent(completedCount, workList.Count);
            AttendanceProgress.Value = Percent(attendedCount, workList.Count);
        }

        private static double Percent(int value, int total)
        {
            return total == 0 ? 0 : Math.Round(value * 100.0 / total);
        }
    }
}
