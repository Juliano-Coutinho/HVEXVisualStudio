using HVEXTest.Application.Models.Report;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Mapping
{
    public static class ReportMapping
    {
        public static Report ToEntity(this ReportDto report)
        {
            var entity = new Report
            {
                Id = report.Id,
                Name = report.Name,
                Status = report.Status,
                TestId = report.TestId,
                TransformersId = report.TransformersId
            };

            return entity;
        }

        public static ReportDto ToDto(this Report report)
        {
            var Dto = new ReportDto
            {
                Id = report.Id,
                Name = report.Name,
                Status = report.Status,
                TestId = report.TestId,
                TransformersId = report.TransformersId
            };

            return Dto;
        }

        public static ReportFull ToFull(this Report report)
        {
            var reportFull = new ReportFull
            {
                Id = report.Id,
                Name = report.Name,
                Status = report.Status
            };
            return reportFull;
        }
    }
}
