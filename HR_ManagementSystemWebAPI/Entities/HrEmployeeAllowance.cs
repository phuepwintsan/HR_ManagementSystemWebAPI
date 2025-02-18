using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Allowance")]
public partial class HrEmployeeAllowance
{
    [Key]
    [Column("Emp_AllowanceId")]
    public long EmpAllowanceId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    public long AllowanceId { get; set; }

    public string? Description { get; set; }

    public int? Type { get; set; }

    public double? Amount { get; set; }

    [Column("Efficetive_Date", TypeName = "datetime")]
    public DateTime? EfficetiveDate { get; set; }

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

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeAllowances")]
    public virtual HrEmployee Employee { get; set; } = null!;

    [ForeignKey("PaySlipId")]
    [InverseProperty("HrEmployeeAllowances")]
    public virtual HrPaySlip? PaySlip { get; set; }
}
