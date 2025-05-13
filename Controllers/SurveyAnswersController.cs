using Microsoft.AspNetCore.Mvc;
using survey_api.Services;
using survey_api.Entities;
using survey_api.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace survey_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyAnswersController : ControllerBase
    {
        private readonly SurveyAnswerService _answerService;
        private readonly SurveyService _surveyService;
        private readonly ILogger<SurveyAnswersController> _logger;

        public SurveyAnswersController(SurveyAnswerService answerService, SurveyService surveyService, ILogger<SurveyAnswersController> logger)
        {
            _answerService = answerService;
            _surveyService = surveyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SurveyAnswers>>> GetAnswers()
        {
            try
            {
                List<SurveyAnswers> asnwerList = await _answerService.GetAllAsync();
                return Ok(asnwerList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyAnswers>> GetAnswer(int id)
        {
            try
            {
                SurveyAnswers answer = await _answerService.GetByIdAsync(id);
                if (answer == null)
                {
                    return NotFound("Answer Not Found");
                }
                return Ok(answer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SurveyAnswers>> CreateAnswer([FromBody] List<SurveyAnswerDto> answers)
        {
            try
            {
                var createdAnswers = new List<SurveyAnswers>();
                if (answers == null)
                {
                    return BadRequest("Payload Empty");
                }

                Surveys survey = await _surveyService.CreateAsync();
                foreach (var answer in answers)
                {
                    var created = await _answerService.CreateAsync(answer, survey);
                    if (created != null)
                    {
                        createdAnswers.Add(created);
                    }
                }
                return Ok(new
                {
                    message = "Answer created successfully",
                    survey = createdAnswers
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, [FromBody] SurveyAnswers answer)
        {
            try
            {
                if (answer == null)
                {
                    return BadRequest("Payload Empty");
                }
                SurveyAnswers updatedAns = await _answerService.UpdateAsync(answer);
                return Ok(new
                {
                    message = "Answer updated successfully",
                    survey = updatedAns
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                await _answerService.DeleteAsync(id);
                return Ok(new { message = "Answer deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
