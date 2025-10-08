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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _service.GetAllTrainingsAsync();
            var dtoList = _mapper.Map<List<TrainingProgramDto>>(trainings);
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var training = await _service.GetTrainingByIdAsync(id);
            if (training == null) return NotFound();
            var dto = _mapper.Map<TrainingProgramDto>(training);
            return Ok(dto);
        }

        [HttpPost]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTrainingAsync(id);
            return NoContent();
        }


    }

}
