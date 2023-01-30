using HVEXTest.Application.Models.Test;
using HVEXText.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Mapping
{
    public static class TestMapping
    {
        public static Test ToEntity(this TestDto testDto)
        {
            var entity = new Test
            {
                Id = testDto.Id,
                Name = testDto.Name,
                Status = testDto.Status,
                DurationInSeconds = testDto.DurationInSeconds
            };

            return entity;
        }

        public static TestDto ToDto(this Test test)
        {
            var Dto = new TestDto
            {
                Id = test.Id,
                Name = test.Name,
                Status = test.Status,
                DurationInSeconds = test.DurationInSeconds
            };

            return Dto;
        }
    }
}
