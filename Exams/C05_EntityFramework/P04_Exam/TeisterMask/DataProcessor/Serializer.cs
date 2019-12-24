namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(p => p.Tasks.Count() >= 1)
                .Select(p => new ExportProjectDto
                {
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks
                                .Select(t => new ExportProjectTaskDto
                                {
                                    Name = t.Name,
                                    Label = t.LabelType.ToString()
                                })
                                .OrderBy(t => t.Name)
                                .ToArray(),
                    TotalTasks = p.Tasks
                                .Select(t => new ExportProjectTaskDto
                                {
                                    Name = t.Name,
                                    Label = t.LabelType.ToString()
                                })
                                .OrderBy(t => t.Name)
                                .Count()
                })
                .ToArray()
                .OrderByDescending(p => p.Tasks.Count())
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employee = context
                .Employees
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                            .Select(et => et.Task)
                            .Where(t => t.OpenDate >= date)
                            .OrderByDescending(t => t.DueDate)
                            .ThenBy(t => t.Name)
                            .Select(t => new ExportTaskDto
                            {
                                TaskName = t.Name,
                                OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                LabelType = t.LabelType.ToString(),
                                ExecutionType = t.ExecutionType.ToString()
                            })
                            .ToArray()
                })
                .ToArray()
                .Where(e => e.Tasks.Count() >= 1)
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(employee, Formatting.Indented);
        }
    }
}