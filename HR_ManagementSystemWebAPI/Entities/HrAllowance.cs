using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Allowance")]
public partial class HrAllowance
{
    [Key]
    public long AllowanceId { get; set; }

    [StringLength(5)]
    public string? CompanyId { get; set; }

    public long? BranchId { get; set; }

    public long? DeptId { get; set; }

    public long? PositionId { get; set; }

    [StringLength(256)]
    public string? AllowanceName { get; set; }

    public string? Description { get; set; }

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
