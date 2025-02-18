using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Deduction")]
public partial class HrEmployeeDeduction
{
    [Key]
    [Column("Emp_DeductionId")]
    public long EmpDeductionId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    public long DeductionId { get; set; }

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

    [ForeignKey("DeductionId")]
    [InverseProperty("HrEmployeeDeductions")]
    public virtual HrDeduction Deduction { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeDeductions")]
    public virtual HrEmployee Employee { get; set; } = null!;

    [ForeignKey("PaySlipId")]
    [InverseProperty("HrEmployeeDeductions")]
    public virtual HrPaySlip? PaySlip { get; set; }
}
