using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace survey_api.Entities
{
    public class Surveys
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubmitTime { get; set; }
        public string Status { get; set; }
        public DateTime CompletionDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
