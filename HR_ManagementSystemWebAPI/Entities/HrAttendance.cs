using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Attendance")]
public partial class HrAttendance
{
    [Key]
    public long AttendId { get; set; }

    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    public int LogType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AttendLog { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public int LateMins { get; set; }

    public int EarlyLeaveMins { get; set; }

    [Column("OTHour")]
    public int Othour { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrAttendances")]
    public virtual HrEmployee Employee { get; set; } = null!;
}
