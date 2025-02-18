using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployeeHistory
{
    public long HistoryId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public long? PositionId { get; set; }

    [Column("Promotion_PositionId")]
    public long? PromotionPositionId { get; set; }

    [StringLength(256)]
    public string? PositionName { get; set; }

    [Column("Promotion_PositionName")]
    [StringLength(256)]
    public string? PromotionPositionName { get; set; }

    [Column("Effective_Date")]
    public DateOnly? EffectiveDate { get; set; }

    [Column("Previous_Salary")]
    public double? PreviousSalary { get; set; }

    [Column("New_Salary")]
    public double? NewSalary { get; set; }

    [Column("Previous_DeptId")]
    public long? PreviousDeptId { get; set; }

    [Column("Previous_DeptName")]
    [StringLength(256)]
    public string? PreviousDeptName { get; set; }

    [Column("New_DeptId")]
    public long? NewDeptId { get; set; }

    [Column("New_DeptName")]
    [StringLength(256)]
    public string? NewDeptName { get; set; }

    [Column("Previous_BranchId")]
    public long? PreviousBranchId { get; set; }

    [Column("Previous_BranchName")]
    [StringLength(256)]
    public string? PreviousBranchName { get; set; }

    [Column("New_BranchId")]
    public long? NewBranchId { get; set; }

    [Column("New_BranchName")]
    [StringLength(256)]
    public string? NewBranchName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedOn { get; set; }

    [StringLength(256)]
    public string? DeletedBy { get; set; }

    public string? Remark { get; set; }
}
