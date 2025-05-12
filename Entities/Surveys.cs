using System.ComponentModel.DataAnnotations;

namespace survey_api.Entities
{
    public class Surveys : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubmitTime { get; set; }
    }
}
