﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrEmployeeSchedule
{
    public long ScheduleId { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    public bool? IsSunday { get; set; }

    [Column("1_BusinessDayStartHour")]
    public TimeOnly? _1BusinessDayStartHour { get; set; }

    [Column("1_BusinessDayEndHour")]
    public TimeOnly? _1BusinessDayEndHour { get; set; }

    public bool IsMonday { get; set; }

    [Column("2_BusinessDayStartHour")]
    public TimeOnly? _2BusinessDayStartHour { get; set; }

    [Column("2_BusinessDayEndHour")]
    public TimeOnly? _2BusinessDayEndHour { get; set; }

    public bool IsTuesday { get; set; }

    [Column("3_BusinessDayStartHour")]
    public TimeOnly? _3BusinessDayStartHour { get; set; }

    [Column("3_BusinessDayEndHour")]
    public TimeOnly? _3BusinessDayEndHour { get; set; }

    public bool IsWednesday { get; set; }

    [Column("4_BusinessDayStartHour")]
    public TimeOnly? _4BusinessDayStartHour { get; set; }

    [Column("4_BusinessDayEndHour")]
    public TimeOnly? _4BusinessDayEndHour { get; set; }

    public bool IsThursday { get; set; }

    [Column("5_BusinessDayStartHour")]
    public TimeOnly? _5BusinessDayStartHour { get; set; }

    [Column("5_BusinessDayEndHour")]
    public TimeOnly? _5BusinessDayEndHour { get; set; }

    public bool IsFriday { get; set; }

    [Column("6_BusinessDayStartHour")]
    public TimeOnly? _6BusinessDayStartHour { get; set; }

    [Column("6_BusinessDayEndHour")]
    public TimeOnly? _6BusinessDayEndHour { get; set; }

    public bool IsSaturday { get; set; }

    [Column("7_BusinessDayStartHour")]
    public TimeOnly? _7BusinessDayStartHour { get; set; }

    [Column("7_BusinessDayEndHour")]
    public TimeOnly? _7BusinessDayEndHour { get; set; }

    public bool IsCurrent { get; set; }

    [Column("IsOTPaid")]
    public bool IsOtpaid { get; set; }

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
}
