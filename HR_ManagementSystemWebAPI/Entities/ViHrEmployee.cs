using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployee
{
    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(50)]
    public string? Code { get; set; }

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [Column("NRC")]
    [StringLength(50)]
    public string? Nrc { get; set; }

    [StringLength(256)]
    public string? Qualification { get; set; }

    [StringLength(256)]
    public string? Education { get; set; }

    public string? PhoneNumber { get; set; }

    [StringLength(256)]
    public string? OtherPhone { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? HouseNo { get; set; }

    public int? StreetId { get; set; }

    [StringLength(256)]
    public string? StreetName { get; set; }

    public int? TownshipId { get; set; }

    [StringLength(200)]
    public string? TownshipName { get; set; }

    public int? StateId { get; set; }

    [StringLength(200)]
    public string? StateName { get; set; }

    [StringLength(256)]
    public string? Profile { get; set; }

    [StringLength(256)]
    public string? FingerPrint { get; set; }

    [StringLength(50)]
    public string? FingerPrintNo { get; set; }

    [StringLength(256)]
    public string? DrivingLicense { get; set; }

    public bool IsSignAgreement { get; set; }

    public DateOnly? ResignDate { get; set; }

    public double Salary { get; set; }

    [StringLength(3)]
    public string? Currency { get; set; }

    public double LoanAmt { get; set; }

    public int Status { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public long BranchId { get; set; }

    [StringLength(256)]
    public string? BranchName { get; set; }

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    public long? PositionId { get; set; }

    [StringLength(256)]
    public string? PositionName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedOn { get; set; }

    [StringLength(256)]
    public string? DeletedBy { get; set; }

    public string? Remark { get; set; }

    [StringLength(256)]
    public string? RoleName { get; set; }
}
