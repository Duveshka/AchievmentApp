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
             Summary = "Get list of educations"
        )]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEducations(int userId)
        {
            var educations = await _repo.GetEducations(userId);
            return Ok(educations);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Delete current education"
        )]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEducation(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var workFromRepo = await _repo.GetEducation(id);
            _repo.Delete(workFromRepo);

            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Failed to delete");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Add education"
        )]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEducation(int userId, [FromBody]EducationDTO educationForAddd)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await _repo.AddEducation(userId, educationForAddd);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Edit current education"
        )]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditEducation(int userId, int id,
         [FromBody]EducationDTO educationForEdit)
        {
            
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            _repo.EditEducation(id, educationForEdit);
            await _repo.SaveAll();
            return Ok();
        }
    }
}