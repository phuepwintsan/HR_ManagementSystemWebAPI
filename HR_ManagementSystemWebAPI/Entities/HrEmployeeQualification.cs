using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Qualification")]
public partial class HrEmployeeQualification
{
    [Key]
    [Column("QualificationID")]
    public long QualificationId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string QualificationName { get; set; } = null!;

    [StringLength(256)]
    public string? InstitutionName { get; set; }

    public DateOnly? DateObtained { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    [StringLength(50)]
    public string? Grade { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [StringLength(256)]
    public string? FileAttach { get; set; }

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
    [InverseProperty("HrEmployeeQualifications")]
    public virtual HrEmployee Employee { get; set; } = null!;
}
