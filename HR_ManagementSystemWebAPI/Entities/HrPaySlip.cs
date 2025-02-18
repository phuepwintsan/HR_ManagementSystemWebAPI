using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_PaySlip")]
public partial class HrPaySlip
{
    [Key]
    [StringLength(10)]
    public string PayslipId { get; set; } = null!;

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    public DateOnly? PaidOn { get; set; }

    public double? Salary { get; set; }

    [Column("Allowance_Amt")]
    public double? AllowanceAmt { get; set; }

    [Column("Deduction_Amt")]
    public double? DeductionAmt { get; set; }

    [Column("Net_Amt")]
    public double? NetAmt { get; set; }

    public bool? IsTransferBankAccount { get; set; }

    [StringLength(256)]
    public string? BankAccountNo { get; set; }

    public bool Status { get; set; }

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
    [InverseProperty("HrPaySlips")]
    public virtual HrEmployee? Employee { get; set; }

    [InverseProperty("PaySlip")]
    public virtual ICollection<HrEmployeeAllowance> HrEmployeeAllowances { get; set; } = new List<HrEmployeeAllowance>();

    [InverseProperty("PaySlip")]
    public virtual ICollection<HrEmployeeDeduction> HrEmployeeDeductions { get; set; } = new List<HrEmployeeDeduction>();
}
