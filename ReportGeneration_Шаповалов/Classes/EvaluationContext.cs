using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class EvaluationContext
    {
        public List<Evaluation> AllEvaluations()
        {
            DataTable table = ContextTools.Select("SELECT * FROM `Evaluation`");
            List<Evaluation> evaluations = new List<Evaluation>();

            foreach (DataRow row in table.Rows)
            {
                evaluations.Add(new Evaluation(
                    ContextTools.IntValue(row, "Id"),
                    ContextTools.IntValue(row, "IdStudent"),
                    ContextTools.IntValue(row, "IdWork"),
                    ContextTools.StringValue(row, "Value"),
                    ContextTools.StringValue(row, "Lateness")));
            }

            return evaluations;
        }
    }
}
