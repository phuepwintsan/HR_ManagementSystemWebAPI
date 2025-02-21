using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrStatesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrStatesController(HRDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [EndpointSummary("Create States")]
        public async Task<IActionResult> CreateState([FromBody] HrState state)
        {
            if (await _context.HrStates.AnyAsync(x => x.StateId == state.StateId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "SateId already exist"
                });
            }

            _context.HrStates.Add(state);
            await _context.SaveChangesAsync();
            return Created("api/HrStates", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = state,
                Message = "Successfully created"
            });
        }

        [HttpGet]
        [EndpointSummary("Get all States")]
        public async Task<IActionResult> GetallStates()
        {
            List<HrState> state = await _context.HrStates.ToListAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = state,
                Message = "List all States"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by State Id")]
        public async Task<IActionResult> GetbyStateId(int id)
        {
            var states = await _context.HrStates.FirstOrDefaultAsync(x => x.StateId == id);
            if (states == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "SateId not found"
                });
            }

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = states,
                Message = "StateId is OK"
            });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update States")]
        public async Task<IActionResult> UpdateState(int id)
        {
            var state = await _context.HrStates.FirstOrDefaultAsync(x => x.StateId == id);
            if (state == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "StateId not found"
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = state,
                Message = "Successfully updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by StateId")]
        public async Task<IActionResult> DeleteByStateId(int id)
        {
            var state = await _context.HrStates.FindAsync(id);
            if (state == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "StateId not found"
                });
            }

            _context.HrStates.Remove(state);
            await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = state,
                Message = "Successfully Deleted"
            });
        }
    }
}
