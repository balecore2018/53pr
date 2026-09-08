using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class GroupContext
    {
        public List<Group> AllGroups()
        {
            DataTable table = ContextTools.LoadFirst("group", "groups");
            List<Group> groups = new List<Group>();

            foreach (DataRow row in table.Rows)
            {
                groups.Add(new Group(
                    ContextTools.IntValue(row, "id", "id_group", "group_id"),
                    ContextTools.StringValue(row, "name", "title", "number", "group")));
            }

            return groups;
        }
    }
}
