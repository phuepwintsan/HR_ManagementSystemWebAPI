using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Announcement")]
public partial class HrAnnouncement
{
    [Key]
    public long Id { get; set; }

    [StringLength(256)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [StringLength(50)]
    public string? Img { get; set; }

    [StringLength(5)]
    public string? CompanyId { get; set; }

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    public DateOnly? StartOn { get; set; }

    public DateOnly? EndOn { get; set; }

    public bool IsNotify { get; set; }

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
