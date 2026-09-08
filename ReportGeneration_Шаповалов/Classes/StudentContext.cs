using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class StudentContext
    {
        public List<Student> AllStudents()
        {
            DataTable table = ContextTools.Select("SELECT * FROM `Student` ORDER BY `LastName`, `FirstName`");
            List<Student> students = new List<Student>();

            foreach (DataRow row in table.Rows)
            {
                students.Add(new Student(
                    ContextTools.IntValue(row, "Id"),
                    ContextTools.IntValue(row, "IdGroup"),
                    ContextTools.StringValue(row, "LastName"),
                    ContextTools.StringValue(row, "FirstName"),
                    string.Empty,
                    ContextTools.BoolValue(row, "Expelled")));
            }

            return students;
        }
    }
}
