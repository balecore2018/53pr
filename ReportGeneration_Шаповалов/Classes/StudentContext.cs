using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class StudentContext
    {
        public List<Student> AllStudents()
        {
            DataTable table = ContextTools.LoadFirst("student", "students");
            List<Student> students = new List<Student>();

            foreach (DataRow row in table.Rows)
            {
                students.Add(new Student(
                    ContextTools.IntValue(row, "id", "id_student", "student_id"),
                    ContextTools.IntValue(row, "group_id", "id_group"),
                    ContextTools.StringValue(row, "surname", "last_name", "family"),
                    ContextTools.StringValue(row, "name", "first_name"),
                    ContextTools.StringValue(row, "patronymic", "middle_name")));
            }

            return students;
        }
    }
}
