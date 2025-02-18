using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Branch")]
public partial class HrBranch
{
    [Key]
    public long BranchId { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    [StringLength(256)]
    public string? BranchName { get; set; }

    [StringLength(256)]
    public string? ContactPerson { get; set; }

    [StringLength(256)]
    public string? PrimaryPhone { get; set; }

    [StringLength(256)]
    public string? OtherPhone { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? HouseNo { get; set; }

    public int? StreetId { get; set; }

    [StringLength(256)]
    public string? StreetName { get; set; }

    public int? TownshipId { get; set; }

    public int? StateId { get; set; }

    [StringLength(256)]
    public string? Photo { get; set; }

    public bool IsDefault { get; set; }

    public bool IsAutoDeduction { get; set; }

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

    [ForeignKey("CompanyId")]
    [InverseProperty("HrBranches")]
    public virtual HrCompany Company { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } = new List<HrDepartment>();

    [InverseProperty("Branch")]
    public virtual ICollection<HrLeaveGroup> HrLeaveGroups { get; set; } = new List<HrLeaveGroup>();
}
