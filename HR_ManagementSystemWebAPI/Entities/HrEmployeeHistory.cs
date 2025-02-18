using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_History")]
public partial class HrEmployeeHistory
{
    [Key]
    public long HistoryId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    public long? PositionId { get; set; }

    [Column("Promotion_PositionId")]
    public long? PromotionPositionId { get; set; }

    [Column("Effective_Date")]
    public DateOnly? EffectiveDate { get; set; }

    [Column("Previous_Salary")]
    public double? PreviousSalary { get; set; }

    [Column("New_Salary")]
    public double? NewSalary { get; set; }

    [Column("Previous_DeptId")]
    public long? PreviousDeptId { get; set; }

    [Column("New_DeptId")]
    public long? NewDeptId { get; set; }

    [Column("Previous_BranchId")]
    public long? PreviousBranchId { get; set; }

    [Column("New_BranchId")]
    public long? NewBranchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedOn { get; set; }

    [StringLength(256)]
    public string? DeletedBy { get; set; }

    public string? Remark { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeHistories")]
    public virtual HrEmployee Employee { get; set; } = null!;
}
