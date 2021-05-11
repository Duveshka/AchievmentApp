using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetWorks(int userId)
        {
            var works = await _repo.GetWorks(userId);
            return Ok(works);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Delete current work"
        )]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var workFromRepo = await _repo.GetWork(id);
            _repo.Delete(workFromRepo);

            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Failed to delete");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Add work"
        )]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddWork(int userId, [FromBody]WorkDTO workForAddd)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await _repo.AddWork(userId, workForAddd);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Edit current work"
        )]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditWork(int userId, int id,
         [FromBody]WorkDTO workForEdit)
        {
            
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            _repo.EditWork(id, workForEdit);
            await _repo.SaveAll();
            return Ok();
        }
    }
}