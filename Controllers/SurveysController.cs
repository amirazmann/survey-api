using Microsoft.AspNetCore.Mvc;
using survey_api.Services;
using survey_api.Entities;

namespace survey_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : ControllerBase
    {
        private readonly SurveyService _surveyService;
        private readonly ILogger<SurveysController> _logger;

        public SurveysController(SurveyService surveyService, ILogger<SurveysController> logger)
        {
            _surveyService = surveyService;
            _logger = logger;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<List<Surveys>>> GetSurveys()
        {
            try
            {
                List<Surveys> surveyList = await _surveyService.GetAllAsync();
                return Ok(surveyList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surveys>> GetSurvey(int id)
        {
            try
            {
                Surveys survey = await _surveyService.GetByIdAsync(id);
                if (survey == null)
                {
                    return NotFound("Survey Not Found");
                }
                return Ok(survey);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Surveys
        [HttpPost]
        public async Task<ActionResult<Surveys>> CreateSurvey()
        {
            try
            {

                Surveys createdSurvey = await _surveyService.CreateAsync();
                return Ok(new 
                {
                    message = "Survey created successfully",
                    survey = createdSurvey
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, Surveys survey)
        {
            try
            {
                if (survey == null)
                {
                    return BadRequest("Payload Empty");
                }

                Surveys updatedSurvey = await _surveyService.UpdateAsync(survey);
                return Ok(new
                {
                    message = "Survey updated successfully",
                    survey = updatedSurvey
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            try
            {
                await _surveyService.DeleteAsync(id);
                return Ok(new { message = "Survey deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
