using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class DisciplineContext
    {
        public List<Discipline> AllDisciplines()
        {
            DataTable table = ContextTools.LoadFirst("discipline", "disciplines");
            List<Discipline> disciplines = new List<Discipline>();

            foreach (DataRow row in table.Rows)
            {
                disciplines.Add(new Discipline(
                    ContextTools.IntValue(row, "id", "id_discipline", "discipline_id"),
                    ContextTools.StringValue(row, "name", "title", "discipline")));
            }

            return disciplines;
        }
    }
}
