using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployeeAllowance
{
    [Column("Emp_AllowanceId")]
    public long EmpAllowanceId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    public string? PhoneNumber { get; set; }

    [StringLength(256)]
    public string? Profile { get; set; }

    public long AllowanceId { get; set; }

    [StringLength(256)]
    public string? AllowanceName { get; set; }

    public string? Description { get; set; }

    public int? Type { get; set; }

    public double? Amount { get; set; }

    [Column("Efficetive_Date", TypeName = "datetime")]
    public DateTime? EfficetiveDate { get; set; }

    [StringLength(256)]
    public string? OtherPhone { get; set; }

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

    public bool Status { get; set; }

    [StringLength(10)]
    public string? PaySlipId { get; set; }

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
}
