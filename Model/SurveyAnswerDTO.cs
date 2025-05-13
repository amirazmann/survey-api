namespace survey_api.Model
{
    public class SurveyAnswerDto
    {
        public int SurveyId { get; set; }
        public int SurveyQuestionId { get; set; }
        public string Answer { get; set; }
        public string? CreatedBy { get; set; }
    }

}
