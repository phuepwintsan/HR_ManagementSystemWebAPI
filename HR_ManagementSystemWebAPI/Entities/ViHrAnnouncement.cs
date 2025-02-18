using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrAnnouncement
{
    public long Id { get; set; }

    [StringLength(256)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [StringLength(50)]
    public string? Img { get; set; }

    [StringLength(5)]
    public string? CompanyId { get; set; }

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(256)]
    public string? EmployeeName { get; set; }

    public DateOnly? StartOn { get; set; }

    public DateOnly? EndOn { get; set; }

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
