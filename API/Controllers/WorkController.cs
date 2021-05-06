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
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository _repo;
        public WorkController(IWorkRepository repo)
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
            var works = await _repo.GetWorks(userId);
            return Ok(works);
        }
    }
}