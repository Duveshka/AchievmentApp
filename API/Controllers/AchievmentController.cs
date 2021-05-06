using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
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
        [HttpGet]
        public async Task<IActionResult> GetAchievments(int userId)
        {
            var achievments = await _repo.GetAchievments(userId);
            return Ok(achievments);
        }
        
        [ProducesResponseType(typeof(IEnumerable<AchievmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns all achievments of current achievment"
        )]
        [HttpGet("{typeId}")]
        public async Task<IActionResult> GetAchievmentsOfType(int userId, int typeId)
        {
            var achievments = await _repo.GetAchievmentsOfType(userId, typeId);
            return Ok(achievments);
        }
    }
}