using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrDepartmentsController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrDepartmentsController(HRDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[EndpointSummary("Get all Departments")]
        //public async Task<IActionResult> GetallDepartments()
        //{
        //    List<HrDepartment> department = await _context.HrDepartments.ToListAsync();
        //    return Ok(new DefaultResponseModel()
        //    {
        //        Success = true,
        //        Statuscode = StatusCodes.Status200OK,
        //        Data = department,
        //        Message = "List of all Department"
        //    });
        //}

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ViHrDepartment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrDepartments.Where(x => !x.DeletedOn.HasValue).ToListAsync()
            });
        }

        [HttpGet("by-departmentId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ViHrDepartment>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ViHrDepartment?>> GetByIdAsync(long id)
        {
            var viDepartment = await _context.ViHrDepartments.Where(x => x.DeptId == id).ToListAsync();
            return viDepartment != null
                ? Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = viDepartment,
                    Message = "Department Data Found."
                })
                : NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Message = "Department Data Not Found."
                });
        }

        [HttpGet("by-CBid")]
        public async Task<IActionResult> GetByCompanyByBranchAsync(string companyid, long? branchid)
        {
            IReadOnlyList<ViHrDepartment>? department = [];

            // CompanyId, BranchId
            if (!string.IsNullOrEmpty(companyid) && branchid.HasValue)
            {
                department = await _context.ViHrDepartments.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyid && x.BranchId == branchid).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(companyid))
            {
                department = await _context.ViHrDepartments.Where(x =>
                !x.DeletedOn.HasValue && x.CompanyId == companyid).ToListAsync();
            }

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = department,
            });
        }

        [HttpGet("byName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ViHrDepartment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByNameAsync(string deptName, string companyId, long? branchId)
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrDepartments.Where(x => !x.DeletedOn.HasValue && x.DeptName == deptName && x.CompanyId == companyId && x.BranchId == branchId).ToListAsync(),
                Message = "Department Is Already Exist."
            });
        }

        [HttpPost]
        [EndpointSummary("Create Department")]
        public async Task<IActionResult> CreateDepartment([FromForm] HrDepartment department)
        {
            if (await _context.HrDepartments.AnyAsync(x => x.DeptId == department.DeptId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Department already exist"
                });
            }

            _ = _context.HrDepartments.Add(department);
            _ = await _context.SaveChangesAsync();

            return Created("api/HrDepartments", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = department,
                Message = "Created successfully"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by DepartmentId")]
        public async Task<IActionResult> GetbyDepartmentId(long id)
        {
            HrDepartment? department = await _context.HrDepartments.FirstOrDefaultAsync(x => x.DeptId == id);
            return department == null
                ? BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Department Id not found"
                })
                : Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = department,
                    Message = "Department is Ok"
                });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update Department")]
        public async Task<IActionResult> UpdateDepartment(long id, long branchId, string newname)
        {
            HrDepartment? department = await _context.HrDepartments.FirstOrDefaultAsync(x => x.DeptId == id);
            if (department == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Department Id not found"
                });
            }

            department.BranchId = branchId;
            department.DeptName = newname;

            _ = await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = department,
                Message = "Department Id is successfully updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by department Id")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            HrDepartment? department = await _context.HrDepartments.FindAsync(id);
            if (department == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Data = null,
                    Message = "Department Id not found"
                });
            }

            _ = _context.HrDepartments.Remove(department);
            _ = await _context.SaveChangesAsync();
            return Ok(new { message = "Deleted successfully" });
        }

        [HttpGet("positions-with-departments")]
        [EndpointSummary("Get Positions with Department Names")]
        public async Task<IActionResult> GetPositionList(long deptid)
        {
            var query = from position in _context.HrPositions
                        join department in _context.HrDepartments
                        on position.DeptId equals department.DeptId
                        where position.DeptId == deptid
                        select position;

            var list = await query.ToListAsync();
            return Ok(list);
        }

        [HttpGet("allowances-with-positions")]
        [EndpointSummary("Get Allowances with Position Names")]
        public async Task<IActionResult> GetAllowancesWithPositions(long positionId)
        {
            var query = from allowance in _context.HrAllowances
                        join position in _context.HrPositions
                        on allowance.PositionId equals position.PositionId
                        where allowance.PositionId == positionId
                        select allowance;

            var list = await query.CountAsync();
            return Ok(list);
        }

    }
}
