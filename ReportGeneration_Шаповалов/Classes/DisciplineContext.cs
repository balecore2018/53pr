using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class DisciplineContext
    {
        public List<Discipline> AllDisciplines()
        {
            DataTable table = ContextTools.Select("SELECT * FROM `Discipline` WHERE `IsVisible` = 1 ORDER BY `Name`");
            List<Discipline> disciplines = new List<Discipline>();

            foreach (DataRow row in table.Rows)
            {
                disciplines.Add(new Discipline(
                    ContextTools.IntValue(row, "Id"),
                    ContextTools.IntValue(row, "IdGroup"),
                    ContextTools.StringValue(row, "Name")));
            }

            return disciplines;
        }
    }
}
