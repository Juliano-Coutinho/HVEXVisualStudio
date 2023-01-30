using HVEXTest.Application.Models.Transformer;
using HVEXText.Data.Entities;

namespace HVEXTest.Application.Mapping
{
    public static class TransformerMapping
    {
        public static Transformer ToEntity(this TransformerDto transformerDto)
        {
            var entity = new Transformer
            {
                Id = transformerDto.Id,
                Name = transformerDto.Name,
                TensionClass = transformerDto.TensionClass,
                Potency = transformerDto.Potency,
                Current = transformerDto.Current,
                InternalNumber= transformerDto.InternalNumber
            };

            if (transformerDto.TestsId is null) entity.TestsId = new List<string>();
            else entity.TestsId = transformerDto.TestsId;


            if (transformerDto.ReportsId is null) entity.ReportsId = new List<string>();
            else entity.ReportsId = transformerDto.ReportsId;

            return entity;
        }

        public static TransformerDto ToDto(this Transformer transformer)
        {
            var Dto = new TransformerDto
            {
                Id = transformer.Id,
                Name = transformer.Name,
                TensionClass = transformer.TensionClass,
                Potency = transformer.Potency,
                Current = transformer.Current,
                InternalNumber = transformer.InternalNumber
            };

            if (transformer.TestsId is null) Dto.TestsId = new List<string>();
            else Dto.TestsId = transformer.TestsId;

            if (transformer.ReportsId is null) Dto.ReportsId= new List<string>();
            else Dto.ReportsId = transformer.ReportsId;

            return Dto;
        }
    }
}
