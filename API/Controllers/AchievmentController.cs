using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/{userId}/[controller]")]
    public class AchievmentController : ControllerBase
    {
        private readonly IAchievmentRepository _repo;
        public AchievmentController(IAchievmentRepository repo)
        {
            _repo = repo;
        }

        [ProducesResponseType(typeof(IEnumerable<AchievmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns all achievments of current user"
        )]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAchievments(int userId)
        {
            // if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();
            var achievments = await _repo.GetAchievments(userId);
            return Ok(achievments);
        }
        
        [ProducesResponseType(typeof(IEnumerable<AchievmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns all achievments of current achievment"
        )]
        [Authorize]
        [HttpGet("{typeId}")]
        public async Task<IActionResult> GetAchievmentsOfType(int userId, int typeId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var achievments = await _repo.GetAchievmentsOfType(userId, typeId);
            return Ok(achievments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Delete current achievment"
        )]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievment(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var achievmentFromRepo = await _repo.GetAchievment(id);
            _repo.Delete(achievmentFromRepo);

            if (await _repo.SaveAll())
                return Ok();
            return BadRequest("Failed to delete");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Add achievment"
        )]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAchievment(int userId, [FromBody]AchievmentToAddAndEditDTO achievmentForAddd)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            await _repo.AddAchievment(userId, achievmentForAddd);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Edit current achievment"
        )]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAchievment(int userId, int id,
         [FromBody]AchievmentToAddAndEditDTO achievmentForEditDTO)
        {
            
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            _repo.EditAchievment(id, achievmentForEditDTO);
            await _repo.SaveAll();

            return Ok();
        }
    }
}