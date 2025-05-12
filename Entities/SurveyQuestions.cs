using System.ComponentModel.DataAnnotations;

namespace survey_api.Entities
{
    public class SurveyQuestions : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
    }
}
