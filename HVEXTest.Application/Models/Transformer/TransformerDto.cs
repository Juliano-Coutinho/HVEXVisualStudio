using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HVEXTest.Application.Models.Transformer
{
    public class TransformerDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? InternalNumber { get; set; }
        public string? TensionClass { get; set; }
        public string? Potency { get; set; }
        public string? Current { get; set; }
        public IEnumerable<string>? TestsId { get; set; }
        public IEnumerable<string>? ReportsId { get; set; }
    }
}
