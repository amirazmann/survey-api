using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

        public async Task<List<Surveys>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync();
        }


        public async Task<Surveys> GetByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task<Surveys> CreateAsync()
        {
            Surveys newSurvey = new Surveys();
            newSurvey.SubmitTime = DateTime.UtcNow;
            newSurvey.Status = "New";

            newSurvey.CreatedAt = DateTime.UtcNow;
            newSurvey.CreatedBy = "System";

            _context.Surveys.Add(newSurvey);
            await _context.SaveChangesAsync();

            return newSurvey;
        }

        public async Task<Surveys> UpdateAsync(Surveys survey)
        {
            Surveys updateSurvey = new Surveys();
            updateSurvey.SubmitTime = DateTime.UtcNow;

            updateSurvey.ModifiedAt = DateTime.UtcNow;
            updateSurvey.ModifiedBy = "System";

            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task DeleteAsync(int id)
        {
            Surveys survey = await GetByIdAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }
    }
} 