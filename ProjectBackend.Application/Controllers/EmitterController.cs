using ProjectBackend.Business.Services;
using ProjectBackend.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using ProjectBackend.Contracts.ServiceInterfaces;

namespace ProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmitterController : ControllerBase
    {

        private readonly IEmitterService<EmitterDTO> _service;

        public EmitterController(IEmitterService<EmitterDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post(EmitterDTO dto)
        {
            
            var result = await _service.AddAsync(dto);
            return Ok(result);
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var emitter = await _service.GetByIdAsync(id);
            if (emitter == null) return NotFound();
            return Ok(emitter);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<LaserDTO>> Update(int id, EmitterDTO emitterDto)
        {
            
            var result = await _service.UpdateAsync(id, emitterDto);
            if (result == null) return NotFound();
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emitter = await _service.GetByIdAsync(id);
            if (emitter == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("check-name-unique")]
        public async Task<IActionResult> CheckNameUnique(string name, int? excludeId = null)
        {
            var isUnique = await _service.IsNameUniqueAsync(name, excludeId);
            return Ok(new { isUnique });
        }

        [HttpGet("check-spotno-unique")]
        public async Task<IActionResult> CheckSpotNoUnique(string spotNo, int? excludeId = null)
        {
            var isUnique = await _service.IsSpotNoUniqueAsync(spotNo, excludeId);
            return Ok(new { isUnique });
        }

    }
}
