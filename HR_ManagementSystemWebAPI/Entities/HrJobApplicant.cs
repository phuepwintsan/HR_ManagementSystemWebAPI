using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Job_Applicant")]
public partial class HrJobApplicant
{
    [Key]
    public long ApplyId { get; set; }

    public long JobId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ApplyDate { get; set; }

    [StringLength(256)]
    public string? FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(1)]
    public string? Gender { get; set; }

    [StringLength(256)]
    public string? Qualification { get; set; }

    [StringLength(256)]
    public string? Education { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? Address { get; set; }

    [StringLength(256)]
    public string? Docs { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(5)]
    public string? CompanyId { get; set; }

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

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrJobApplicants")]
    public virtual HrEmployee? Employee { get; set; }

    //[ForeignKey("JobId")]
    //[InverseProperty("HrJobApplicants")]
    //public virtual HrJobOpening Job { get; set; } = null!;
}
