using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Deduction")]
public partial class HrDeduction
{
    [Key]
    public long DeductionId { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    public long BranchId { get; set; }

    public long DeptId { get; set; }

    [StringLength(256)]
    public string DeductionName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDefault { get; set; }

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

    [InverseProperty("Deduction")]
    public virtual ICollection<HrEmployeeDeduction> HrEmployeeDeductions { get; set; } = new List<HrEmployeeDeduction>();

    [InverseProperty("Deduction")]
    public virtual ICollection<HrRule> HrRules { get; set; } = new List<HrRule>();
}
