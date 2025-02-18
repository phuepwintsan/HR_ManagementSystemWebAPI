using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Payment_Voucher")]
public partial class HrEmployeePaymentVoucher
{
    [Key]
    [StringLength(10)]
    public string VoucherNo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime VourcharDate { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    public int? VoucherType { get; set; }

    public bool IsClearance { get; set; }

    public double Amount { get; set; }

    public double ClearnaceAmount { get; set; }

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
