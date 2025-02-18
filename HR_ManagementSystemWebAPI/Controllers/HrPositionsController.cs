using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrPositionsController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrPositionsController(HRDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EndpointSummary("Get all Positions")]
        public async Task<IActionResult> GetallPositions()
        {
            List<HrPosition> positions = await _context.HrPositions.ToListAsync();
            _ = positions.Count;
            return Ok(new DefaultResponseModel
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = positions,
                Message = "List of all HR position"
            });
        }

        [HttpPost]
        [EndpointSummary("Create Position")]
        public async Task<IActionResult> CreatePosition([FromForm] HrPosition position)
        {
            if (await _context.HrPositions.AnyAsync(x => x.PositionId == position.PositionId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Position is already exist"
                });
            }

            _ = _context.HrPositions.Add(position);
            _ = await _context.SaveChangesAsync();

            return Created("api/HrPositions", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = position,
                Message = "Position is successfully created"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by PositionId")]
        public async Task<IActionResult> GetbyPositionId(long id)
        {
            HrPosition? positon = await _context.HrPositions.FirstOrDefaultAsync(x => x.PositionId == id);
            return positon == null
                ? BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "PositionId not found"
                })
                : Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = positon,
                    Message = "Position is Ok"
                });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update by Position Id")]
        public async Task<IActionResult> UpdatePosition(long id, string newname)
        {
            HrPosition? positon = await _context.HrPositions.FirstOrDefaultAsync(x => x.PositionId == id);
            if (positon == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status200OK,
                    Data = null,
                    Message = "Position Id Not Found"
                });
            }

            positon.PositionName = newname;
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = positon,
                Message = "Successfully updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by position Id")]
        public async Task<IActionResult> DeletePosition(long id)
        {
            HrPosition? positon = await _context.HrPositions.FindAsync(id);
            if (positon == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Position Id not found"
                });
            }

            _ = _context.HrPositions.Remove(positon);
            _ = await _context.SaveChangesAsync();
            return Ok(new { message = "Deleted successfully" });
        }
    }
}