using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_LoanType")]
public partial class HrLoanType
{
    [Key]
    public long LoanTypeId { get; set; }

    [StringLength(256)]
    public string? LoanTypeName { get; set; }

    public string? LoanDescription { get; set; }

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

    [ForeignKey("CompanyId")]
    [InverseProperty("HrLoanTypes")]
    public virtual HrCompany? Company { get; set; }
}
