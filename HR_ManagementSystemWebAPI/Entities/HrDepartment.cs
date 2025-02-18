using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Department")]
public partial class HrDepartment
{
    [Key]
    public long DeptId { get; set; }

    public long BranchId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    public long? LeaveGroupId { get; set; }

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
    [InverseProperty("HrDepartments")]
    public virtual HrBranch Branch { get; set; } = null!;

    [InverseProperty("Dept")]
    public virtual ICollection<HrPosition> HrPositions { get; set; } = new List<HrPosition>();

    [ForeignKey("LeaveGroupId")]
    [InverseProperty("HrDepartments")]
    public virtual HrLeaveGroup? LeaveGroup { get; set; }
}
