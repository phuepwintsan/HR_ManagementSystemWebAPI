using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[PrimaryKey("RuleId", "DeductionId", "CalculationType")]
[Table("HR_Rule")]
public partial class HrRule
{
    [Key]
    public long RuleId { get; set; }

    [Key]
    public long DeductionId { get; set; }

    [Key]
    public int CalculationType { get; set; }

    public int? FromRange { get; set; }

    public int? ToRange { get; set; }

    public double? Value { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

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

    [ForeignKey("DeductionId")]
    [InverseProperty("HrRules")]
    public virtual HrDeduction Deduction { get; set; } = null!;
}
