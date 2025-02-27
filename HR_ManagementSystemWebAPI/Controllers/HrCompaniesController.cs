using HR_ManagementSystemWebAPI.Data;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        [EndpointSummary("Get all Companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            List<HrCompany> company = await _context.HrCompanies.ToListAsync();
            return Ok(new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = company,
                Message = "List all Companies"
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

            _context.HrCompanies.Add(hrCompany);
            await _context.SaveChangesAsync();

            return Created("api/HrCompanies", new DefaultResponseModel()
            {
                Success = true,
                Statuscode = StatusCodes.Status200OK,
                Data = hrCompany,
                Message = "Successfully Created"
            });
        }

        [HttpGet("{id}")]
        [EndpointSummary("Get by CompanyId")]
        public async Task<IActionResult> GetByCompanyId(string id)
        {
            var company = await _context.HrCompanies.FirstOrDefaultAsync(x => x.CompanyId == id);
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

            return Ok(new DefaultResponseModel()
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
            var company = await _context.HrCompanies.FirstOrDefaultAsync(x => x.CompanyId == id);
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

            await _context.SaveChangesAsync();
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
            var company = await _context.HrCompanies.FindAsync(id);
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

            _context.HrCompanies.Remove(company);
            await _context.SaveChangesAsync();

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
