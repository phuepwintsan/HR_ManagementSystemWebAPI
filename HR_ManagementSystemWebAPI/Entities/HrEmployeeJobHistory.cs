using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_JobHistory")]
public partial class HrEmployeeJobHistory
{
    [Key]
    [Column("JobHistoryID")]
    public long JobHistoryId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string JobTitle { get; set; } = null!;

    [StringLength(256)]
    public string CompanyName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "text")]
    public string? JobDescription { get; set; }

    public double? Salary { get; set; }

    [StringLength(256)]
    public string? Location { get; set; }

    [StringLength(256)]
    public string? SupervisorName { get; set; }

    [StringLength(256)]
    public string? SupervisorContact { get; set; }

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
    [InverseProperty("HrEmployeeJobHistories")]
    public virtual HrEmployee Employee { get; set; } = null!;
}
