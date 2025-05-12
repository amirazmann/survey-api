using Microsoft.EntityFrameworkCore;
using survey_api.Data;
using survey_api.Entities;

namespace survey_api.Services
{
    public class SurveyService
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task<Survey> CreateAsync(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task<Survey> UpdateAsync(Survey survey)
        {
            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task DeleteAsync(int id)
        {
            var survey = await GetByIdAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Survey>> GetActiveSurveysAsync()
        {
            return await _context.Surveys
                .Where(s => s.IsActive)
                .ToListAsync();
        }
    }
} 