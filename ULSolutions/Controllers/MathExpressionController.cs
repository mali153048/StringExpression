using Microsoft.AspNetCore.Mvc;
using ULSolutions.Services;

namespace ULSolutions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathExpressionController : ControllerBase
    {
        private readonly DmasService _dmasService;
        public MathExpressionController(DmasService dmasService)
        {
            _dmasService = dmasService;
        }

        [HttpPost]
        public ActionResult<double> Evaluate(string stringExpression)
        {
            return _dmasService.Evaluate(stringExpression);
        }
    }
}