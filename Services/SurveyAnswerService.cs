using Microsoft.EntityFrameworkCore;
using survey_api.Data;
using survey_api.Entities;
using Microsoft.Extensions.Logging;
using survey_api.Model;

namespace survey_api.Services
{
    public class SurveyAnswerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SurveyAnswerService> _logger;

        public SurveyAnswerService(ApplicationDbContext context, ILogger<SurveyAnswerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<SurveyAnswers>> GetAllAsync()
        {
            return await _context.SurveyAnswers.Include(s => s.Surveys).Include(sq => sq.SurveyQuestions).ToListAsync();
        }

        public async Task<SurveyAnswers> GetByIdAsync(int id)
        {
            return await _context.SurveyAnswers.FindAsync(id);
        }

        public async Task<SurveyAnswers> CreateAsync(SurveyAnswerDto answer, Surveys survey)
        {
            SurveyAnswers newAnswer = new SurveyAnswers();
            newAnswer.Answer = answer.Answer;
            newAnswer.SurveyQuestionId = answer.SurveyQuestionId;
            newAnswer.SurveyId = survey.Id;

            newAnswer.CreatedAt = DateTime.UtcNow;
            newAnswer.CreatedBy = "System";

            _context.SurveyAnswers.Add(newAnswer);
            await _context.SaveChangesAsync();
            return newAnswer;
        }

        public async Task<SurveyAnswers> UpdateAsync(SurveyAnswers answer)
        {
            SurveyAnswers updateAnswer = new SurveyAnswers();
            updateAnswer.Answer = answer.Answer;
            updateAnswer.SurveyQuestionId = answer.SurveyQuestionId;
            updateAnswer.SurveyId = answer.SurveyId;

            updateAnswer.ModifiedAt = DateTime.UtcNow;
            updateAnswer.ModifiedBy = "System";

            _context.SurveyAnswers.Update(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task DeleteAsync(int id)
        {
            SurveyAnswers answer = await GetByIdAsync(id);
            if (answer != null)
            {
                _context.SurveyAnswers.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }
    }
}