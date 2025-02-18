using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrJobOpening
{
    public long Id { get; set; }

    [StringLength(256)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int NoOfApplicants { get; set; }

    public DateOnly? StartOn { get; set; }

    public DateOnly? EndOn { get; set; }

    [StringLength(5)]
    public string? CompanyId { get; set; }

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public long? BranchId { get; set; }

    [StringLength(256)]
    public string? BranchName { get; set; }

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    public long? PositionId { get; set; }

    [StringLength(256)]
    public string? PositionName { get; set; }

    public bool OpeningStatus { get; set; }

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
