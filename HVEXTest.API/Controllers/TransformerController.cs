using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Models.Transformer;
using HVEXText.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HVEXTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransformerController : ControllerBase
    {
        private readonly ITransformerService _transformerService;

        public TransformerController(ITransformerService transformerService)
        {
            _transformerService = transformerService;
        }

        [HttpGet]
        public async Task<List<TransformerDto>> GetTransformersAsync() =>
            await _transformerService.GetTransformers();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TransformerDto>> GetTransformerAsyn(string id)
        {
            var transformer = await _transformerService.GetTransformerById(id);

            if (transformer is null)
            {
                return NotFound();
            }

            return transformer;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransformerDto newTransformer)
        {
            var response = await _transformerService.AddTransformer(newTransformer);

            if (response.Id is not null) return CreatedAtAction(nameof(GetTransformerAsyn), new { id = response.Id }, response);

            else return BadRequest();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TransformerDto updatedTransformer)
        {
            var transformer = await _transformerService.GetTransformerById(id);

            if (transformer is null)
            {
                return NotFound();
            }

            await _transformerService.updateTransformer(id, updatedTransformer);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var transformer = _transformerService.GetTransformerById(id);

            if (transformer is null)
            {
                return NotFound();
            }

            await _transformerService.DeleteTransformer(id);

            return NoContent();
        }
    }
}