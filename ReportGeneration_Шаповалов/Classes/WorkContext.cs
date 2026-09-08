using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class WorkContext
    {
        public List<Work> AllWorks()
        {
            DataTable table = ContextTools.LoadFirst("work", "works");
            List<Work> works = new List<Work>();

            foreach (DataRow row in table.Rows)
            {
                works.Add(new Work(
                    ContextTools.IntValue(row, "id", "id_work", "work_id"),
                    ContextTools.IntValue(row, "discipline_id", "id_discipline"),
                    ContextTools.StringValue(row, "name", "title", "topic", "work"),
                    ContextTools.DateValue(row, "date", "work_date")));
            }

            return works;
        }
    }
}
