using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrCompaniesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public HrCompaniesController(HRDbContext context)
        {
            _context = context;
        }

        //[HttpGet("by-companyName")]
        //[EndpointSummary("Get all Companies")]
        //public async Task<IActionResult> GetAllCompanies()
        //{
        //    List<HrCompany> company = await _context.HrCompanies.ToListAsync();
        //    return Ok(new DefaultResponseModel()
        //    {
        //        Success = true,
        //        Statuscode = StatusCodes.Status200OK,
        //        Data = company,
        //        Message = "List all Companies"
        //    });
        //}

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ViHrCompany>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = await _context.ViHrCompanies.Where(x => !x.DeletedOn.HasValue).ToListAsync()
            });
        }

        [HttpPost]
        [EndpointSummary("Create Company")]
        public async Task<IActionResult> CreateCompany([FromBody] HrCompany hrCompany)
        {
            if (await _context.HrCompanies.AnyAsync(x => x.CompanyId == hrCompany.CompanyId))
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Company Id doesn't exist"
                });
            }

            _ = _context.HrCompanies.Add(hrCompany);
            _ = await _context.SaveChangesAsync();

            return Created("api/HrCompanies", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = hrCompany,
                Message = "Successfully Created"
            });
        }

        [HttpGet("by-companyid")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ViHrCompany), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViHrCompany?>> GetByIdAsync(string id)
        {
            List<ViHrCompany> ViCompany = await _context.ViHrCompanies.Where(x => x.CompanyId == id).ToListAsync();
            return ViCompany != null
                ? Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = ViCompany,
                    Message = "Company data found."
                })
                : NotFound(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status404NotFound,
                    Message = "Company data not found."
                });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by CompanyId")]
        public async Task<IActionResult> GetByCompanyId(string id)
        {
            HrCompany? company = await _context.HrCompanies.FirstOrDefaultAsync(x => x.CompanyId == id);
            return company == null
                ? BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Company Id doesn't exist"
                })
                : Ok(new DefaultResponseModel()
                {
                    Success = true,
                    Statuscode = StatusCodes.Status200OK,
                    Data = company,
                    Message = "Ok"
                });
        }

        [HttpPut("{id}")]
        [EndpointSummary("Update by company id")]
        public async Task<IActionResult> UpdateByCompanyId(string id, [FromBody] HrCompany hrCompany)
        {
            HrCompany? company = await _context.HrCompanies.FirstOrDefaultAsync(x => x.CompanyId == id);
            if (company == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Company Id doesn't exists"
                });

            }

            company.Status = hrCompany.Status;
            company.Email = hrCompany.Email;
            company.StreetId = hrCompany.StreetId;
            company.CompanyName = hrCompany.CompanyName;
            company.ContactPerson = hrCompany.ContactPerson;
            company.CreatedBy = hrCompany.CreatedBy;
            company.CreatedOn = DateTime.Now;
            company.UpdatedBy = hrCompany.UpdatedBy;
            company.UpdatedOn = DateTime.Now;

            _ = await _context.SaveChangesAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = company,
                Message = "Successfully Updated"
            });
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Delete by company Id")]
        public async Task<IActionResult> DeleteByCompanyId(string id)
        {
            HrCompany? company = await _context.HrCompanies.FindAsync(id);
            if (company == null)
            {
                return BadRequest(new DefaultResponseModel()
                {
                    Success = false,
                    Statuscode = StatusCodes.Status400BadRequest,
                    Data = null,
                    Message = "Company Id doesn't exist"
                });
            }

            _ = _context.HrCompanies.Remove(company);
            _ = await _context.SaveChangesAsync();

            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = company,
                Message = "Successfully Deleted"
            });
        }
    }
}
