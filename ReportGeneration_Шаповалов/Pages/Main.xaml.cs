using System.Windows.Controls;
using System.Windows;
using ReportGeneration_Шаповалов.Classes;
using ReportGeneration_Шаповалов.Classes.Common;
using ReportGeneration_Шаповалов.Models;
using StudentItem = ReportGeneration_Шаповалов.Items.Student;

namespace ReportGeneration_Шаповалов.Pages
{
    public partial class Main : Page
    {
        private readonly List<Group> groups = new List<Group>();
        private readonly List<Discipline> disciplines = new List<Discipline>();
        private readonly List<Models.Student> students = new List<Models.Student>();
        private readonly List<Models.Work> works = new List<Models.Work>();
        private readonly List<Evaluation> evaluations = new List<Evaluation>();

        public Main()
        {
            InitializeComponent();
            LoadData();
            CreateGroupUI();
            CreateStudents();
        }

        private void LoadData()
        {
            disciplines.Clear();
            disciplines.AddRange(new DisciplineContext().AllDisciplines());
            works.Clear();
            works.AddRange(new WorkContext().AllWorks());
            evaluations.Clear();
            evaluations.AddRange(new EvaluationContext().AllEvaluations());
        }

        private void CreateGroupUI()
        {
            groups.Clear();
            groups.Add(new Group(0, "Все группы"));
            groups.AddRange(new GroupContext().AllGroups());

            Groups.ItemsSource = null;
            Groups.ItemsSource = groups;
            Groups.SelectedIndex = 0;
        }

        private void CreateStudents()
        {
            students.Clear();
            students.AddRange(new StudentContext().AllStudents());
            RenderStudents(students);
        }

        private void SelectGroup(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void SelectStudents(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            RenderStudents(GetFilteredStudents());
        }

        private IEnumerable<Models.Student> GetFilteredStudents()
        {
            IEnumerable<Models.Student> result = students;

            if (Groups.SelectedItem is Group selectedGroup && selectedGroup.Id != 0)
            {
                result = result.Where(student => student.GroupId == selectedGroup.Id);
            }

            string search = Search.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = result.Where(student => student.FullName.ToLower().Contains(search));
            }

            return result;
        }

        private void RenderStudents(IEnumerable<Models.Student> source)
        {
            List<Models.Student> studentList = source.ToList();
            List<Models.Work> visibleWorks = GetVisibleWorks().ToList();
            List<int> visibleWorkIds = visibleWorks.Select(work => work.Id).ToList();
            List<Evaluation> visibleEvaluations = evaluations
                .Where(evaluation => visibleWorkIds.Contains(evaluation.WorkId))
                .ToList();

            Parent.Children.Clear();

            if (studentList.Count == 0)
            {
                StatusText.Text = "Данные не найдены. Восстановите базу journal из файла journal.sql и запустите OpenServer/MySQL.";
                return;
            }

            StatusText.Text = $"Найдено студентов: {studentList.Count}";

            foreach (Models.Student student in studentList)
            {
                Parent.Children.Add(new StudentItem(student, visibleWorks, visibleEvaluations));
            }
        }

        private IEnumerable<Models.Work> GetVisibleWorks()
        {
            if (Groups.SelectedItem is not Group selectedGroup || selectedGroup.Id == 0)
            {
                return works;
            }

            List<int> disciplineIds = disciplines
                .Where(discipline => discipline.GroupId == selectedGroup.Id)
                .Select(discipline => discipline.Id)
                .ToList();

            return works.Where(work => disciplineIds.Contains(work.DisciplineId));
        }

        private void ReportGeneration(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                List<Models.Student> selectedStudents = GetFilteredStudents().ToList();
                List<Models.Work> selectedWorks = GetVisibleWorks().ToList();
                string groupName = Groups.SelectedItem is Group selectedGroup
                    ? selectedGroup.Name
                    : "Все группы";

                if (selectedStudents.Count == 0)
                {
                    MessageBox.Show("Нет студентов для отчёта.", "Excel", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string path = new Report().Create(selectedStudents, selectedWorks, evaluations, groupName);
                MessageBox.Show($"Отчёт сохранён: {path}", "Excel", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка генерации отчёта", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
