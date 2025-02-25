using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrPoliciesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrPoliciesController(HRDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EndpointSummary("Get all Policies")]
        public async Task<IActionResult> GetPolicies()
        {
            List<HrPolicy> policy = await _context.HrPolicies.ToListAsync();
            return Ok(new DefaultResponseModel
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = policy,
                Message = "List all Policies"
            });
        }

        [HttpPost]
        [EndpointSummary("Create policy")]
        public async Task<IActionResult> CreatePolicy([FromBody] HrPolicy policy)
        {
            if (await _context.HrPolicies.AnyAsync(x => x.Id == policy.Id))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "policy id already exist"
                });
            }

            _ = _context.HrPolicies.Add(policy);
            _ = await _context.SaveChangesAsync();

            return Created("api/HrPolicies", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = policy,
                Message = "Successfully created"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by Policy Id")]
        public async Task<IActionResult> GetByPolicyId(long id)
        {
            HrPolicy? policy = await _context.HrPolicies.FirstOrDefaultAsync(x => x.Id == id);
            return policy == null
                ? NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Policy Id not found"
                })
                : Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = policy,
                    Message = "Policy Id is OK"
                });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update by policy id")]
        public async Task<IActionResult> UpdateByPolicyId(long id, [FromBody] HrPolicy hrpolicy)
        {
            HrPolicy? policy = await _context.HrPolicies.FirstOrDefaultAsync(x => x.Id == id);
            if (policy == null)
            {
                return NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Policy Id not found"
                });
            }

            policy.Title = hrpolicy.Title;
            policy.Description = hrpolicy.Description;
            _ = await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = policy,
                Message = "Successfully updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by policy id")]
        public async Task<IActionResult> DeleteByPolicyID(long id)
        {
            HrPolicy? policy = await _context.HrPolicies.FindAsync(id);
            if (policy == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Policy id not found"
                });
            }
            _ = _context.HrPolicies.Remove(policy);
            _ = await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = policy,
                Message = "Successfully deleted"
            });
        }

    }
}
