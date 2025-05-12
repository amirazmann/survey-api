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

        public SurveysController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            var surveys = await _surveyService.GetAllAsync();
            return Ok(surveys);
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            var survey = await _surveyService.GetByIdAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        // POST: api/Surveys
        [HttpPost]
        public async Task<ActionResult<Survey>> CreateSurvey(Survey survey)
        {
            var createdSurvey = await _surveyService.CreateAsync(survey);
            return CreatedAtAction(nameof(GetSurvey), new { id = createdSurvey.Id }, createdSurvey);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, Survey survey)
        {
            if (id != survey.Id)
            {
                return BadRequest();
            }

            await _surveyService.UpdateAsync(survey);
            return NoContent();
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _surveyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
