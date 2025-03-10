using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOpensController : ControllerBase
    {
        private readonly HRDbContext _context;

        public JobOpensController(HRDbContext context)
        {
            _context = context;
        }

        #region CRUD Operation

        [HttpGet]
        [EndpointSummary("Get all Job Opening")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrJobOpenings.Where(x => !x.DeletedOn.HasValue).ToListAsync()
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by Id")]
        public async Task<ActionResult<ViHrJobOpening?>> GetByIdAsync(long id)
        {
            ViHrJobOpening? viJobOpening = await _context.ViHrJobOpenings.FirstOrDefaultAsync(x => x.Id == id);
            return viJobOpening != null
                ? Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = viJobOpening,
                    Message = "Job Opening Data Found."
                })
                : NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Message = "Job Opening Data Not Found."
                });
        }

        [HttpPost]
        [EndpointSummary("Create Job Opening")]
        public async Task<IActionResult> CreateJobOpen([FromBody] HrJobOpening jobOpening)
        {
            if (await _context.ViHrJobOpenings.AnyAsync(x => x.Id == jobOpening.Id))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Job Opening Id already exist"
                });
            }

            _context.HrJobOpenings.Add(jobOpening);
           var result = await _context.SaveChangesAsync();

            return result > 0 ?
             Created("api/JobOpens", new DefaultResponseModel()
             {
                 Success = true,
                 Statuscode = StatusCodes.Status200OK,
                 Data = jobOpening,
                 Message = "Created Successfully"
             }) :
                 BadRequest( new DefaultResponseModel()
                 {
                     Success = true,
                     Statuscode = StatusCodes.Status200OK,
                     Data = null,
                     Message = "Job Opening Id already exist"

                 });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update by Job Opening Id")]
        public async Task<IActionResult> UpdateJobOpen(long id, [FromBody] HrJobOpening hrJobOpening)
        {
            var jobOpening = await _context.HrJobOpenings.FindAsync(id);
            if (jobOpening == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Job Opening Id doesn't exist"
                });
            }

            jobOpening.BranchId = hrJobOpening.BranchId;
            jobOpening.CompanyId = hrJobOpening.CompanyId;
            jobOpening.PositionId = hrJobOpening.PositionId;
            jobOpening.EndOn = hrJobOpening.EndOn;
            jobOpening.StartOn = hrJobOpening.StartOn;
            jobOpening.DeptId = hrJobOpening.DeptId;
            jobOpening.Description = hrJobOpening.Description;
            jobOpening.NoOfApplicants = hrJobOpening.NoOfApplicants;
            jobOpening.Remark = hrJobOpening.Remark;
            jobOpening.CreatedOn = DateTime.Now;
            jobOpening.UpdatedOn = DateTime.Now;
            jobOpening.CreatedBy = hrJobOpening.CreatedBy;
            jobOpening.UpdatedBy = "Ari";
            jobOpening.DeletedBy = hrJobOpening.DeletedBy;
            jobOpening.DeletedOn = hrJobOpening.DeletedOn;

            //_context.HrJobOpenings.Update(jobOpening);
            _context.Entry(jobOpening).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return (result > 0) ? Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = jobOpening,
                Message = "Updated Successfully"
            }) :
            BadRequest(new DefaultResponseModel()
            {
                Success = false,
                Statuscode = StatusCodes.Status400BadRequest,
                Data = null,
                Message = "Job opening Id doesn't exist"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete By Id")]
        public async Task<IActionResult> DeleteByJobOpening(long id)
        {
            var jobOpening = await _context.HrJobOpenings.FindAsync(id);
            if (jobOpening == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Job Opening Id doesn't exist"
                });
            }

            _context.HrJobOpenings.Remove(jobOpening);
            var result = await _context.SaveChangesAsync();

            return (result > 0) ?
             Ok(new DefaultResponseModel()
             {
                 Success = true,
                 Statuscode = StatusCodes.Status200OK,
                 Data = jobOpening,
                 Message = "Deleted Successfully"
             }) :
            BadRequest(new DefaultResponseModel()
            {
                Success = false,
                Statuscode = StatusCodes.Status400BadRequest,
                Data = null,
                Message = "Job Opening Id doesn't exist"
            });
        }

        #endregion

        [HttpGet("by-CBDP")]
        [EndpointSummary("Get by CBDP Id")]
        public async Task<IActionResult> GetByAsync(string companyid, long? branchid, long? deptId, long? positionId)
        {
            IReadOnlyList<ViHrJobOpening>? jobOpening = [];

            if (!string.IsNullOrEmpty(companyid) && branchid.HasValue && deptId.HasValue && positionId.HasValue)
            {
                jobOpening = await _context.ViHrJobOpenings.Where(X => !X
                .DeletedOn.HasValue && X.CompanyId == companyid && X.BranchId == branchid && X.DeptId == deptId && X.PositionId == positionId).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyid) && branchid.HasValue && deptId.HasValue)
            {
                jobOpening = await _context.ViHrJobOpenings.Where(X => !X
                .DeletedOn.HasValue && X.CompanyId == companyid && X.BranchId == branchid && X.DeptId == deptId).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyid) && branchid.HasValue)
            {
                jobOpening = await _context.ViHrJobOpenings.Where(X => !X
                .DeletedOn.HasValue && X.CompanyId == companyid && X.BranchId == branchid).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyid))
            {
                jobOpening = await _context.ViHrJobOpenings.Where(X => !X
                .DeletedOn.HasValue && X.CompanyId == companyid).ToListAsync();
            }
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = jobOpening
            });
        }

    }
}
