using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_LeaveType")]
public partial class HrLeaveType
{
    [Key]
    public long LeaveTypeId { get; set; }

    public long LeaveGroupId { get; set; }

    [StringLength(256)]
    public string LeaveName { get; set; } = null!;

    public string? LeaveDescription { get; set; }

    public int LeaveEntitlement { get; set; }

    public int NoOfDaysAllowed { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    public bool IsDeduct { get; set; }

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

    [ForeignKey("LeaveGroupId")]
    [InverseProperty("HrLeaveTypes")]
    public virtual HrLeaveGroup LeaveGroup { get; set; } = null!;
}
