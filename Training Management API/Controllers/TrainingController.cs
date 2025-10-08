using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training_Management_API.DTOs;
using Training_Management_API.Models;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _service;
        private readonly IMapper _mapper;

        public TrainingController(ITrainingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all training programs.
        /// </summary>
        /// <returns>List of training programs as TrainingProgramDto.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _service.GetAllTrainingsAsync();
            var dtoList = _mapper.Map<List<TrainingProgramDto>>(trainings);
            return Ok(dtoList);
        }

        /// <summary>
        /// Retrieves a specific training program by ID including trainer and participants.
        /// </summary>
        /// <param name="id">The ID of the training program.</param>
        /// <returns>TrainingProgramDto when found; 404 if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var training = await _service.GetTrainingByIdAsync(id);
            if (training == null) return NotFound();
            var dto = _mapper.Map<TrainingProgramDto>(training);
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new training program.
        /// </summary>
        /// <param name="dto">CreateTrainingDto containing Title, Description, StartDate, EndDate, TrainerId.</param>
        /// <returns>201 Created with location header when successful; 400 Bad Request for validation errors.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTrainingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.EndDate <= dto.StartDate)
                return BadRequest("End date must be after start date.");

            var training = _mapper.Map<TrainingProgram>(dto);
            await _service.CreateTrainingAsync(training);

            return CreatedAtAction(nameof(GetById), new { id = training.Id }, training);
        }

        /// <summary>
        /// Updates an existing training program.
        /// </summary>
        /// <param name="id">The ID of the training program to update.</param>
        /// <param name="dto">CreateTrainingDto with updated values.</param>
        /// <returns>204 No Content when successful; 400 Bad Request for validation errors.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTrainingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.EndDate <= dto.StartDate)
                return BadRequest("End date must be after start date.");

            var training = _mapper.Map<TrainingProgram>(dto);
            training.Id = id;

            await _service.UpdateTrainingAsync(training);

            return NoContent();
        }

        /// <summary>
        /// Deletes a training program by ID.
        /// </summary>
        /// <param name="id">The ID of the training program to delete.</param>
        /// <returns>204 No Content when successful; 404 Not Found if resource does not exist.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTrainingAsync(id);
            return NoContent();
        }
    }

}
