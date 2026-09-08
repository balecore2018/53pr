using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class GroupContext
    {
        public List<Group> AllGroups()
        {
            DataTable table = ContextTools.Select("SELECT * FROM `Group` ORDER BY `Name`");
            List<Group> groups = new List<Group>();

            foreach (DataRow row in table.Rows)
            {
                groups.Add(new Group(
                    ContextTools.IntValue(row, "Id"),
                    ContextTools.StringValue(row, "Name")));
            }

            return groups;
        }
    }
}
