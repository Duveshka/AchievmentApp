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
    public class AchievmentDetailController : ControllerBase
    {
        private readonly IAchievmentRepository _repo;
        public AchievmentDetailController(IAchievmentRepository repo)
        {
            _repo = repo;
        }

        [ProducesResponseType(typeof(AchievmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "current achievment"
        )]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchievment(int id)
        {
            var achievments = await _repo.GetAchievment(id);
            return Ok(achievments);
        }
    }
}