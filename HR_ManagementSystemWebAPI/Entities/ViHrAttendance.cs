using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrAttendance
{
    public long AttendId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    [StringLength(1)]
    public string Gender { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

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

    public int LogType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AttendLog { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public int LateMins { get; set; }

    public int EarlyLeaveMins { get; set; }

    [Column("OTHour")]
    public int Othour { get; set; }
}
