using ProjectBackend.Business.Services;
using ProjectBackend.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using ProjectBackend.Contracts.ServiceInterfaces;


namespace EHBBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        private readonly IPlatformService<PlatformDTO> _service;
        
        public PlatformsController(IPlatformService<PlatformDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post(PlatformDTO dto)
        {
            
            var result = await _service.AddAsync(dto);
            return Ok(result);
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var platform = await _service.GetByIdAsync(id);
            if (platform == null) return NotFound();
            return Ok(platform);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlatformDTO>> Update(int id, PlatformDTO platformDto)
        {
            
                var result = await _service.UpdateAsync(id, platformDto);
                if (result == null) return NotFound();
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var platform = await _service.GetByIdAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }






    }
}
