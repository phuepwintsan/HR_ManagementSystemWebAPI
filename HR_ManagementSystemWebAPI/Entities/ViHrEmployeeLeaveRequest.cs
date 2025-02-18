using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployeeLeaveRequest
{
    public long RequestId { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestDate { get; set; }

    public long? RelatedTypeId { get; set; }

    [StringLength(256)]
    public string? RelatedTypeName { get; set; }

    public string? Description { get; set; }

    [StringLength(256)]
    public string? File1 { get; set; }

    [StringLength(256)]
    public string? File2 { get; set; }

    [StringLength(256)]
    public string? File3 { get; set; }

    public int? RequestStatus { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public long BranchId { get; set; }

    [StringLength(256)]
    public string? BranchName { get; set; }

    public long? DeptId { get; set; }

    [StringLength(256)]
    public string? DeptName { get; set; }

    public long? PositionId { get; set; }

    [StringLength(256)]
    public string? PositionName { get; set; }

    [StringLength(256)]
    public string? ReplyBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReplyDate { get; set; }

    public string? ReplyRemark { get; set; }
}
