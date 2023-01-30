using HVEXTest.Application.Models.Test;
using HVEXTest.Application.Models.Transformer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Models.Report
{
    public class ReportFull
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public TestDto? Test { get; set; }
        public IList<TransformerDto>? Transformers { get; set; }
    }
}
