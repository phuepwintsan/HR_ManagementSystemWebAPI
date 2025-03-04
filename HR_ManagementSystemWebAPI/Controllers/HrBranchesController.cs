using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrBranchesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrBranchesController(HRDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[EndpointSummary("Get all branches")]
        //public async Task<IActionResult> GetAllBranches()
        //{
        //    List<HrBranch> branch = await _context.HrBranches.ToListAsync();
        //    return Ok(new DefaultResponseModel()
        //    {
        //        Success = true,
        //        Statuscode = StatusCodes.Status200OK,
        //        Data = branch,
        //        Message = "List all Branches"
        //    });
        //}

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ViHrBranch>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrBranches.Where(x => !x.DeletedOn.HasValue).ToListAsync()
            });
        }

        [HttpPost]
        [EndpointSummary("Create branch")]
        public async Task<IActionResult> CreateBranch([FromBody] HrBranch hrBranch)
        {
            if (await _context.HrBranches.AnyAsync(x => x.BranchId == hrBranch.BranchId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "BranchId already exist"
                });
            }

            _context.HrBranches.Add(hrBranch);
            await _context.SaveChangesAsync();

            return Created("api/HrBranches", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = hrBranch,
                Message = "Successfully created"

            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by BranchId")]
        public async Task<IActionResult> GetByBranchId(long id)
        {
            var branch = await _context.HrBranches.FirstOrDefaultAsync(x => x.BranchId == id);
            if (branch == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Branch Id is not found"
                });
            }

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = branch,
                Message = "Ok"
            });
        }

        [HttpGet("by-branchid")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ViHrBranch), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViHrBranch?>> GetByIdAsync(long id)
        {
            var ViBranch = await _context.ViHrBranches.Where(x => x.BranchId == id).ToListAsync();
            return ViBranch != null
                ? Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = ViBranch,
                    Message = "Branch data found."
                })
                : NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Message = "Branch data not found."
                });
        }

        [HttpGet("by-companyId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ViHrBranch), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViHrBranch?>> GetByDeptIdAsync(string companyId)
        {
            return Ok(new DefaultResponseModel()
            {
                Statuscode = StatusCodes.Status200OK,
                Success = true,
                Data = await _context.ViHrBranches.Where(x => x.CompanyId == companyId && !x.DeletedOn.HasValue).ToListAsync()
            });
        }


        [HttpPut("{id}")]
        [EndpointSummary("Update by Branch Id")]
        public async Task<IActionResult> UpdateByBranchId(long id, [FromBody] HrBranch hrBranch)
        {
            var branch = await _context.HrBranches.FirstOrDefaultAsync(x => x.BranchId == id);
            if(branch == null)
            {
                return BadRequest(new DefaultResponseModel()
                { 
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "BranchId doesn't exist"
                });
            }

            branch.BranchName = hrBranch.BranchName;
            branch.Status = hrBranch.Status;
            branch.Email = hrBranch.Email;
            branch.StreetId = hrBranch.StreetId;
            branch.Company = hrBranch.Company;
            branch.ContactPerson = hrBranch.ContactPerson;
            branch.OtherPhone = hrBranch.OtherPhone;
            branch.PrimaryPhone = hrBranch.PrimaryPhone;
            branch.Remark = hrBranch.Remark;
            branch.TownshipId = hrBranch.TownshipId;
            branch.HouseNo = hrBranch.HouseNo;
            branch.StateId = hrBranch.StateId;
            branch.Photo = hrBranch.Photo;
            branch.CreatedBy = hrBranch.CreatedBy;
            branch.CreatedOn = DateTime.Now;
            branch.UpdatedBy = hrBranch.UpdatedBy;
            branch.UpdatedOn = DateTime.Now;
            branch.IsAutoDeduction = hrBranch.IsAutoDeduction;
            branch.IsDefault = hrBranch.IsDefault;

            await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = branch,
                Message = "Successfully Updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by branch id")]
        public async Task<IActionResult> DeleteByBranchId(long id)
        {
            var branch = await _context.HrBranches.FindAsync(id);
            if(branch == null)
            {
                return NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "BranchId not found"
                });
            }

            _context.HrBranches.Remove(branch);
            await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = branch,
                Message = "Successfully Deleted"
            });
        }
    }
}