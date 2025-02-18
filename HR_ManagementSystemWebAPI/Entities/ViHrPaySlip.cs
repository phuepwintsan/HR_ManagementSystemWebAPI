using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrPaySlip
{
    [StringLength(10)]
    public string PayslipId { get; set; } = null!;

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

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

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    public long? PositionId { get; set; }

    [StringLength(256)]
    public string? PositionName { get; set; }

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
}
