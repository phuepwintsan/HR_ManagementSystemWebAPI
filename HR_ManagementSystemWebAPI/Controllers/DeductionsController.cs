using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionsController : ControllerBase
    {
        private readonly HRDbContext _context;

        public DeductionsController(HRDbContext context) => _context = context;

        [HttpGet]
        [EndpointSummary("Get all Deduction")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrDeductions.Where(x => !x.DeletedOn.HasValue).ToListAsync()
            });
        }

        [HttpGet("by-CBDPid")]
        [EndpointSummary("Get by CBDPid")]
        public async Task<IActionResult> GetByCompanyAsync(string companyId, long? branchId, long? dept, long? positionId)
        {
            IReadOnlyList<ViHrDeduction> deduction = [];


            if (!string.IsNullOrEmpty(companyId) && branchId.HasValue && dept.HasValue && positionId.HasValue)
            {
                deduction = await _context.ViHrDeductions.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyId && x.BranchId == branchId && x.DeptId == dept).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyId) && branchId.HasValue && dept.HasValue)
            {
                deduction = await _context.ViHrDeductions.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyId && x.BranchId == branchId && x.DeptId == dept).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyId) && branchId.HasValue)
            {
                deduction = await _context.ViHrDeductions.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyId && x.BranchId == branchId).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyId))
            {
                deduction = await _context.ViHrDeductions.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyId).ToListAsync();
            }

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = deduction
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by DeductionId")]
        public async Task<ActionResult<ViHrDeduction>> GetByIdAsync(long deductionId)
        {
            var deduction = await _context.ViHrDeductions.FirstOrDefaultAsync(x => x.DeductionId == deductionId);
            return deduction != null ?
                Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = deduction,
                    Message = "Deduction data found"
                })
                : NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Deduction data not found"
                });
        }

        [HttpGet("by-deptId")]
        [EndpointSummary("Get by department Id")]
        public async Task<ActionResult<ViHrDeduction>> GetByDeptIdAsync(long deptId)
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrDeductions.FirstOrDefaultAsync(x => x.DeptId == deptId && !x.DeletedOn.HasValue)
            });
        }

        //[HttpPost]
        //[EndpointSummary("Create Deduction")]
        //public async Task<IActionResult> CreateAllowance([FromBody] HrAllowance deduction)
        //{
        //    if (await _context.HrAllowances.AnyAsync(x => x.a == deduction.DeductionId))
        //    {
        //        return BadRequest(new DefaultResponseModel()
        //        {
        //            Success = false,
        //            Statuscode = StatusCodes.Status400BadRequest,
        //            Data = null,
        //            Message = "DeductionId is already exist"
        //        });
        //    }

        //    _ = _context.HrDeductions.Add(deduction);
        //    _ = await _context.SaveChangesAsync();

        //    return Created("api/HrAllowances", new DefaultResponseModel()
        //    {
        //        Success = true,
        //        Statuscode = StatusCodes.Status200OK,
        //        Data = deduction,
        //        Message = "Created successfully"
        //    });
        //}

        [HttpPost]
        [EndpointSummary("Create Deduction")]
        public async Task<IActionResult> CreateDeduction([FromBody] HrDeduction hrDeduction)
        {
            if (await _context.HrDeductions.AnyAsync(x => x.DeductionId == hrDeduction.DeductionId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "DeductionId is already exist"
                });
            }

            _context.HrDeductions.Add(hrDeduction);
            await _context.SaveChangesAsync();

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = hrDeduction,
                Message = "Created Successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeduction(long id, [FromBody] HrDeduction hrDeduction)
        {
            var deduction = await _context.HrDeductions.FirstOrDefaultAsync(x => x.DeductionId == id);
            if (deduction == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Deduction id not found"
                });
            }

            deduction.BranchId = hrDeduction.BranchId;
            deduction.CompanyId = hrDeduction.CompanyId;
            deduction.DeductionName = hrDeduction.DeductionName;
            deduction.Status = hrDeduction.Status;
            deduction.CreatedBy = hrDeduction.CreatedBy;
            deduction.CreatedOn = DateTime.Now;
            deduction.DeletedBy = hrDeduction.DeletedBy;
            deduction.DeletedOn = DateTime.Now;
            deduction.Remark = hrDeduction.Remark;
            deduction.UpdatedBy = hrDeduction.UpdatedBy;
            deduction.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = deduction,
                Message = "Updated Successfully"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by deductin Id")]
        public async Task<IActionResult> DeleteByDeductionId(long id)
        {
            var deduction = await _context.HrDeductions.FindAsync(id);
            if (deduction == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Deducting Id not found"
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = deduction,
                Message = "Deleted Successfully"
            });
        }
    }
}