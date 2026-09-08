using ReportGeneration_Шаповалов.Models;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    public class EvaluationContext
    {
        public List<Evaluation> AllEvaluations()
        {
            DataTable table = ContextTools.LoadFirst("evaluation", "evaluations", "mark", "marks");
            List<Evaluation> evaluations = new List<Evaluation>();

            foreach (DataRow row in table.Rows)
            {
                evaluations.Add(new Evaluation(
                    ContextTools.IntValue(row, "id", "id_evaluation", "evaluation_id"),
                    ContextTools.IntValue(row, "student_id", "id_student"),
                    ContextTools.IntValue(row, "work_id", "id_work"),
                    ContextTools.IntValue(row, "value", "mark", "grade", "evaluation"),
                    ContextTools.BoolValue(row, "is_visited", "visited", "attendance", "is_attended")));
            }

            return evaluations;
        }
    }
}
