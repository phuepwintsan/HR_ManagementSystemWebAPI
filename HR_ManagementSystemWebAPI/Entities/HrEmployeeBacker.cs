using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[PrimaryKey("BackerId", "EmployeeId")]
[Table("HR_Employee_Backer")]
public partial class HrEmployeeBacker
{
    [Key]
    public long BackerId { get; set; }

    [Key]
    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string? Relative { get; set; }

    [Column("NRC")]
    [StringLength(256)]
    public string? Nrc { get; set; }

    [StringLength(256)]
    public string? Phone { get; set; }

    public string? DetailAddress { get; set; }

    [StringLength(256)]
    public string? Occupation { get; set; }

    [StringLength(256)]
    public string? File1 { get; set; }

    [StringLength(256)]
    public string? File2 { get; set; }

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
    [InverseProperty("HrEmployeeBackers")]
    public virtual HrEmployee Employee { get; set; } = null!;
}
