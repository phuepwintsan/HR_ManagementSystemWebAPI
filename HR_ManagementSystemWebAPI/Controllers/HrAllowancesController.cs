using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HrAllowancesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrAllowancesController(HRDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EndpointSummary("Get all Allowance")]
        public async Task<IActionResult> GetallAllowances()
        {
            List<HrAllowance> allowance = await _context.HrAllowances.ToListAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = allowance,
                Message = "List of all allowance"
            });
        }

        [HttpPost]
        [EndpointSummary("Create Allowance")]
        public async Task<IActionResult> CreateAllowance([FromForm] HrAllowance allowance)
        {
            if (await _context.HrAllowances.AnyAsync(x => x.AllowanceId == allowance.AllowanceId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Allowance not found"
                });
            }

            _ = _context.HrAllowances.Add(allowance);
            _ = await _context.SaveChangesAsync();

            return Created("api/HrAllowance", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = allowance,
                Message = "Created successfully"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by allowance Id")]
        public async Task<IActionResult> GetbyAllowanceId(long id)
        {
            HrAllowance? allowance = await _context.HrAllowances.FirstOrDefaultAsync(x => x.AllowanceId == id);
            return allowance == null
                ? BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Allowance Id not found"
                })
                : Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = allowance,
                    Message = "Allowance is Ok"
                });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Allowance")]
        public async Task<IActionResult> UpdateAllowance(long id, HrAllowance hrallowance)
        {
            HrAllowance? allowance = await _context.HrAllowances.FirstOrDefaultAsync(x => x.AllowanceId == id);
            if (allowance == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Allowance Id not found"
                });
            }

            allowance.AllowanceName = hrallowance.AllowanceName;
            allowance.BranchId = hrallowance.BranchId;
            _ = await _context.SaveChangesAsync();
            return Created("api/HrAllowances", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = allowance,
                Message = "Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by allowance Id")]
        public async Task<IActionResult> DeleteAllowance(long id)
        {
            HrAllowance? allowance = await _context.HrAllowances.FindAsync(id);
            if (allowance == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Allowance Id not found"
                });
            }

            _ = _context.HrAllowances.Remove(allowance);
            _ = await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = allowance,
                Message = "Deleted Successfully"
            });
        }
    }
}
