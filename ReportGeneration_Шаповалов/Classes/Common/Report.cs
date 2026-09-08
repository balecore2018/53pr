using ClosedXML.Excel;
using StudentModel = ReportGeneration_Шаповалов.Models.Student;
using WorkModel = ReportGeneration_Шаповалов.Models.Work;
using EvaluationModel = ReportGeneration_Шаповалов.Models.Evaluation;
using System.IO;
using System.Diagnostics;

namespace ReportGeneration_Шаповалов.Classes.Common
{
    public class Report
    {
        public string Create(
            IEnumerable<StudentModel> students,
            IEnumerable<WorkModel> works,
            IEnumerable<EvaluationModel> evaluations,
            string groupName)
        {
            List<StudentModel> studentList = students.ToList();
            List<WorkModel> workList = works.ToList();
            List<EvaluationModel> evaluationList = evaluations.ToList();

            using XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Успеваемость");

            worksheet.Cell(1, 1).Value = $"Отчёт по группе: {groupName}";
            worksheet.Cell(2, 1).Value = "ФИО студента";

            for (int index = 0; index < workList.Count; index++)
            {
                worksheet.Cell(2, index + 2).Value = workList[index].Name;
            }

            for (int studentIndex = 0; studentIndex < studentList.Count; studentIndex++)
            {
                StudentModel student = studentList[studentIndex];
                worksheet.Cell(studentIndex + 3, 1).Value = student.FullName;

                for (int workIndex = 0; workIndex < workList.Count; workIndex++)
                {
                    EvaluationModel? evaluation = evaluationList.FirstOrDefault(item =>
                        item.StudentId == student.Id && item.WorkId == workList[workIndex].Id);

                    worksheet.Cell(studentIndex + 3, workIndex + 2).Value =
                        evaluation == null ? string.Empty : evaluation.Value;
                }
            }

            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 14;

            IXLRange headers = worksheet.Range(2, 1, 2, Math.Max(workList.Count + 1, 1));
            headers.Style.Font.Bold = true;
            headers.Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Columns().AdjustToContents();

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"ReportGeneration_Шаповалов_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

            workbook.SaveAs(path);
            Process.Start(new ProcessStartInfo(path)
            {
                UseShellExecute = true
            });

            return path;
        }
    }
}
