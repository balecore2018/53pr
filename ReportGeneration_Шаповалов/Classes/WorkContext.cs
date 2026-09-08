using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class WorkContext
    {
        public List<Work> AllWorks()
        {
            DataTable table = ContextTools.Select("SELECT * FROM `Work` WHERE IFNULL(`Blocked`, 0) = 0 ORDER BY `Date`, `Name`");
            List<Work> works = new List<Work>();

            foreach (DataRow row in table.Rows)
            {
                works.Add(new Work(
                    ContextTools.IntValue(row, "Id"),
                    ContextTools.IntValue(row, "IdDiscipline"),
                    ContextTools.StringValue(row, "Name"),
                    ContextTools.DateValue(row, "Date")));
            }

            return works;
        }
    }
}
