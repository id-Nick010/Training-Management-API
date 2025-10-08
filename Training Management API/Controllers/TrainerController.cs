using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training_Management_API.DTOs;
using Training_Management_API.Models;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _service;
        private readonly IMapper _mapper;

        public TrainerController(ITrainerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _service.GetAllTrainersAsync();
            var dtoList = _mapper.Map<List<TrainerDto>>(trainers);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer = await _service.GetTrainerByIdAsync(id);
            if (trainer == null) return NotFound();
            var dto = _mapper.Map<TrainerDto>(trainer);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainer = _mapper.Map<Trainer>(dto);
            await _service.CreateTrainerAsync(trainer);
            return CreatedAtAction(nameof(GetById), new { id = trainer.Id }, trainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTrainerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var trainer = _mapper.Map<Trainer>(dto);
            trainer.Id = id;

            await _service.UpdateTrainerAsync(trainer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTrainerAsync(id);
            return NoContent();
        }

    }
}
