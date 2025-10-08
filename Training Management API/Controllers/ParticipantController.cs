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

        /// <summary>
        /// Retrieves all participants.
        /// </summary>
        /// <returns>List of participants as ParticipantDto.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _service.GetAllParticipantsAsync();
            var dtoList = _mapper.Map<List<ParticipantDto>>(participants);
            return Ok(dtoList);
        }

        /// <summary>
        /// Retrieves a specific participant by ID.
        /// </summary>
        /// <param name="id">The ID of the participant.</param>
        /// <returns>ParticipantDto when found; 404 if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _service.GetParticipantByIdAsync(id);
            if (participant == null) return NotFound();
            var dto = _mapper.Map<ParticipantDto>(participant);
            return Ok(dto);
        }

        /// <summary>
        /// Retrieves participants for a specific training program without training details.
        /// </summary>
        /// <param name="trainingId">The ID of the training program.</param>
        /// <returns>List of ParticipantSlimDto for the specified training; 200 OK.</returns>
        [HttpGet("by-training/{trainingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByTrainingProgramId(int trainingId)
        {
            var participants = await _service.GetParticipantsByTrainingProgramIdAsync(trainingId);
            var dtoList = _mapper.Map<List<ParticipantSlimDto>>(participants);
            return Ok(dtoList);
        }

        /// <summary>
        /// Creates a new participant.
        /// </summary>
        /// <param name="dto">CreateParticipantDto containing Name, Department, and TrainingProgramId.</param>
        /// <returns>201 Created with location header when successful; 400 Bad Request for validation errors.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateParticipantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var participant = _mapper.Map<Participant>(dto);
            await _service.CreateParticipantAsync(participant);
            return CreatedAtAction(nameof(GetById), new { id = participant.Id }, participant);
        }

        /// <summary>
        /// Updates an existing participant.
        /// </summary>
        /// <param name="id">The ID of the participant to update.</param>
        /// <param name="dto">CreateParticipantDto with updated values.</param>
        /// <returns>204 No Content when successful; 400 Bad Request for validation errors.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateParticipantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var participant = _mapper.Map<Participant>(dto);
            participant.Id = id;

            await _service.UpdateParticipantAsync(participant);

            return NoContent();
        }

        /// <summary>
        /// Deletes a participant by ID.
        /// </summary>
        /// <param name="id">The ID of the participant to delete.</param>
        /// <returns>204 No Content when successful; 404 Not Found if resource does not exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteParticipantAsync(id);
            return NoContent();
        }
    }

}
