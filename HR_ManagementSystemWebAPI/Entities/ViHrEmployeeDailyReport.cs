using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployeeDailyReport
{
    public long ReportId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportDate { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    public string? PhoneNumber { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }
}
