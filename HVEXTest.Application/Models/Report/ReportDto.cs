using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HVEXTest.Application.Models.Report
{
    public class ReportDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? TestId { get; set; }
        public IEnumerable<string>? TransformersId { get; set; }
    }
}
