using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_LeaveGroup")]
public partial class HrLeaveGroup
{
    [Key]
    public long LeaveGroupId { get; set; }

    [StringLength(256)]
    public string? LeaveGroupName { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    public long BranchId { get; set; }

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

    [ForeignKey("BranchId")]
    [InverseProperty("HrLeaveGroups")]
    public virtual HrBranch Branch { get; set; } = null!;

    [ForeignKey("CompanyId")]
    [InverseProperty("HrLeaveGroups")]
    public virtual HrCompany Company { get; set; } = null!;

    [InverseProperty("LeaveGroup")]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } = new List<HrDepartment>();

    [InverseProperty("LeaveGroup")]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; set; } = new List<HrLeaveType>();
}
