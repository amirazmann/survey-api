using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace survey_api.Entities
{
    public class SurveyAnswers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }
        public int SurveyId { get; set; }
        public Surveys Surveys { get; set; }
        public int SurveyQuestionId { get; set; }
        public SurveyQuestions SurveyQuestions { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
