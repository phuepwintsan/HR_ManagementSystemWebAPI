using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Request")]
public partial class HrEmployeeRequest
{
    [Key]
    public long RequestId { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestDate { get; set; }

    public int? RequestType { get; set; }

    public long? RelatedTypeId { get; set; }

    public bool IsResign { get; set; }

    public DateOnly? RequestResignDate { get; set; }

    public double? RequestAmount { get; set; }

    public string? Description { get; set; }

    [StringLength(256)]
    public string? File1 { get; set; }

    [StringLength(256)]
    public string? File2 { get; set; }

    [StringLength(256)]
    public string? File3 { get; set; }

    public int? RequestStatus { get; set; }

    [StringLength(256)]
    public string? ReplyBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReplyDate { get; set; }

    public string? ReplyRemark { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeRequests")]
    public virtual HrEmployee? Employee { get; set; }
}
