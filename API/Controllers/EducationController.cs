using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{userId}/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _repo;
        public EducationController(IEducationRepository repo)
        {
            _repo = repo;
        }

        [ProducesResponseType(typeof(WorkDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "list of works"
        )]
        [HttpGet]
        public async Task<IActionResult> GetAchievment(int userId)
        {
            var educations = await _repo.GetEducations(userId);
            return Ok(educations);
        }
    }
}