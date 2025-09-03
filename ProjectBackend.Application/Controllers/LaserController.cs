using ProjectBackend.Business.Services;
using ProjectBackend.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using ProjectBackend.Contracts.ServiceInterfaces;


namespace EHBBProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaserController : ControllerBase
    {
        private readonly ILaserService<LaserDTO> _service;

        public LaserController(ILaserService<LaserDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post(LaserDTO dto)
        {
           
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var laser = await _service.GetByIdAsync(id);
            if (laser == null) return NotFound();
            return Ok(laser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LaserDTO>> Update(int id, LaserDTO laserDto)
        {
           
            var result = await _service.UpdateAsync(id, laserDto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var laser = await _service.GetByIdAsync(id);
            if (laser == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
