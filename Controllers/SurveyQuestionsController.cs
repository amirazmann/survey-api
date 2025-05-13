using Microsoft.AspNetCore.Mvc;
using survey_api.Services;
using survey_api.Entities;

namespace survey_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyQuestionsController : ControllerBase
    {
        private readonly SurveyQuestionService _questionService;
        private readonly ILogger<SurveyQuestionsController> _logger;

        public SurveyQuestionsController(SurveyQuestionService questionService,ILogger<SurveyQuestionsController> logger)
        {
            _questionService = questionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SurveyQuestions>>> GetQuestions()
        {
            try
            {
                List<SurveyQuestions> questionList = await _questionService.GetAllAsync();
                return Ok(questionList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyQuestions>> GetQuestion(int id)
        {
            try
            {
                SurveyQuestions question = await _questionService.GetByIdAsync(id);
                if(question == null)
                {
                    return NotFound("Question Not Found");
                }
                return Ok(question);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SurveyQuestions>> CreateQuestion([FromBody] SurveyQuestions question)
        {
            try
            {
                if(question == null)
                {
                    return BadRequest("Payload Empty");
                }

                SurveyQuestions createdQuestion = await _questionService.CreateAsync(question);
                return Ok(new
                {
                    message = "Survey created successfully",
                    survey = createdQuestion
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] SurveyQuestions question)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest("Payload Empty");
                }
                SurveyQuestions updatedQues = await _questionService.UpdateAsync(question);
                return Ok(new
                {
                    message = "Question updated successfully",
                    survey = updatedQues
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                await _questionService.DeleteAsync(id);
                return Ok(new { message = "Question deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
