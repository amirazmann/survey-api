using System.ComponentModel.DataAnnotations;

namespace survey_api.Entities
{
    public class SurveyAnswers : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Surveys Surveys { get; set; }
        public int SurveyQuestionId { get; set; }
        public SurveyQuestions SurveyQuestions { get; set; }
        public string Answer { get; set; }
    }
}
