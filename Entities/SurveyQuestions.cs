using System.ComponentModel.DataAnnotations;using System.ComponentModel.DataAnnotations.Schema;

namespace survey_api.Entities
{
    public class SurveyQuestions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
