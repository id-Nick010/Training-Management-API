using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training_Management_API.DTOs;
using Training_Management_API.Models;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;
        private readonly IMapper _mapper;

        public ParticipantController(IParticipantService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _service.GetAllParticipantsAsync();
            var dtoList = _mapper.Map<List<ParticipantDto>>(participants);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _service.GetParticipantByIdAsync(id);
            if (participant == null) return NotFound();
            var dto = _mapper.Map<ParticipantDto>(participant);
            return Ok(dto);
        }

        [HttpGet("by-training/{trainingId}")]
        public async Task<IActionResult> GetByTrainingProgramId(int trainingId)
        {
            var participants = await _service.GetParticipantsByTrainingProgramIdAsync(trainingId);
            var dtoList = _mapper.Map<List<ParticipantSlimDto>>(participants);
            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParticipantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var participant = _mapper.Map<Participant>(dto);
            await _service.CreateParticipantAsync(participant);
            return CreatedAtAction(nameof(GetById), new { id = participant.Id }, participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateParticipantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var participant = _mapper.Map<Participant>(dto);
            participant.Id = id;

            await _service.UpdateParticipantAsync(participant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteParticipantAsync(id);
            return NoContent();
        }
    }

}
