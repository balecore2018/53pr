using System.Windows.Controls;
using ReportGeneration_Шаповалов.Classes;
using ReportGeneration_Шаповалов.Models;
using StudentItem = ReportGeneration_Шаповалов.Items.Student;

namespace ReportGeneration_Шаповалов.Pages
{
    public partial class Main : Page
    {
        private readonly List<Group> groups = new List<Group>();
        private readonly List<Models.Student> students = new List<Models.Student>();

        public Main()
        {
            InitializeComponent();
            CreateGroupUI();
            CreateStudents();
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

            RenderStudents(result);
        }

        private void RenderStudents(IEnumerable<Models.Student> source)
        {
            Parent.Children.Clear();

            foreach (Models.Student student in source)
            {
                Parent.Children.Add(new StudentItem(student));
            }
        }

        private void ReportGeneration(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}
