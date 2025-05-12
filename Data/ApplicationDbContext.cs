using Microsoft.EntityFrameworkCore;
using survey_api.Entities;

namespace survey_api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure relationships
        modelBuilder.Entity<SurveyAnswers>()
            .HasOne(sa => sa.Surveys)
            .WithMany()
            .HasForeignKey(sa => sa.SurveyId)
            .HasForeignKey(sa => sa.SurveyQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<Surveys> Surveys { get; set; }
    public DbSet<SurveyQuestions> SurveyQuestions { get; set; }
    public DbSet<SurveyAnswers> SurveyAnswers { get; set; }
} 