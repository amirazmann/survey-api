using Microsoft.EntityFrameworkCore;
using survey_api.Data;
using survey_api.Entities;
using Microsoft.Extensions.Logging;

namespace survey_api.Services
{
    public class SurveyQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SurveyQuestionService> _logger;

        public SurveyQuestionService(ApplicationDbContext context, ILogger<SurveyQuestionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<SurveyQuestions>> GetAllAsync()
        {
            return await _context.SurveyQuestions.ToListAsync();
        }

        public async Task<SurveyQuestions> GetByIdAsync(int id)
        {
            return await _context.SurveyQuestions.FindAsync(id);
        }

        public async Task<SurveyQuestions> CreateAsync(SurveyQuestions question)
        {
            SurveyQuestions newQuestion = new SurveyQuestions();
            newQuestion.Question = question.Question;

            newQuestion.CreatedAt = DateTime.UtcNow;
            newQuestion.CreatedBy = "System";

             _context.SurveyQuestions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<SurveyQuestions> UpdateAsync(SurveyQuestions question)
        {
            SurveyQuestions updateQuestion = new SurveyQuestions();
            updateQuestion.Question = question.Question;

            updateQuestion.ModifiedAt = DateTime.UtcNow;
            updateQuestion.ModifiedBy = "System";

            _context.SurveyQuestions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task DeleteAsync(int id)
        {
            SurveyQuestions question = await GetByIdAsync(id);
            if (question != null)
            {
                _context.SurveyQuestions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
} 