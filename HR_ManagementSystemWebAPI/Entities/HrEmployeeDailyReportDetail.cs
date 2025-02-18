using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[PrimaryKey("ReportId", "TitleId")]
[Table("HR_Employee_Daily_Report_Detail")]
public partial class HrEmployeeDailyReportDetail
{
    [Key]
    public long ReportId { get; set; }

    [Key]
    public long TitleId { get; set; }

    public string? Reporting { get; set; }

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

    [ForeignKey("ReportId")]
    [InverseProperty("HrEmployeeDailyReportDetails")]
    public virtual HrEmployeeDailyReport Report { get; set; } = null!;

    [ForeignKey("TitleId")]
    [InverseProperty("HrEmployeeDailyReportDetails")]
    public virtual HrDailyReportTitle Title { get; set; } = null!;
}
