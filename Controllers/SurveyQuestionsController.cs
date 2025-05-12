using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using survey_api.Data;

namespace survey_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyQuestionsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SurveyQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]


    }
}
