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

        /// <summary>
        /// Retrieves all trainers.
        /// </summary>
        /// <returns>List of trainers as TrainerDto.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _service.GetAllTrainersAsync();
            var dtoList = _mapper.Map<List<TrainerDto>>(trainers);
            return Ok(dtoList);
        }

        /// <summary>
        /// Retrieves a specific trainer by ID.
        /// </summary>
        /// <param name="id">The ID of the trainer.</param>
        /// <returns>TrainerDto when found; 404 if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer = await _service.GetTrainerByIdAsync(id);
            if (trainer == null) return NotFound();
            var dto = _mapper.Map<TrainerDto>(trainer);
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new trainer.
        /// </summary>
        /// <param name="dto">CreateTrainerDto containing Name, Email, and Specialization.</param>
        /// <returns>201 Created with location header when successful; 400 Bad Request for validation errors.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTrainerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trainer = _mapper.Map<Trainer>(dto);
            await _service.CreateTrainerAsync(trainer);
            return CreatedAtAction(nameof(GetById), new { id = trainer.Id }, trainer);
        }

        /// <summary>
        /// Updates an existing trainer.
        /// </summary>
        /// <param name="id">The ID of the trainer to update.</param>
        /// <param name="dto">CreateTrainerDto with updated values.</param>
        /// <returns>204 No Content when successful; 400 Bad Request for validation errors.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTrainerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var trainer = _mapper.Map<Trainer>(dto);
            trainer.Id = id;

            await _service.UpdateTrainerAsync(trainer);

            return NoContent();
        }

        /// <summary>
        /// Deletes a trainer by ID.
        /// </summary>
        /// <param name="id">The ID of the trainer to delete.</param>
        /// <returns>204 No Content when successful; 404 Not Found if resource does not exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTrainerAsync(id);
            return NoContent();
        }

    }

}
