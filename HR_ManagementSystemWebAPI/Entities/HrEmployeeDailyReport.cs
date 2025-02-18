using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee_Daily_Report")]
public partial class HrEmployeeDailyReport
{
    [Key]
    public long ReportId { get; set; }

    [StringLength(256)]
    public string? EmployeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("HrEmployeeDailyReports")]
    public virtual HrEmployee? Employee { get; set; }

    [InverseProperty("Report")]
    public virtual ICollection<HrEmployeeDailyReportDetail> HrEmployeeDailyReportDetails { get; set; } = new List<HrEmployeeDailyReportDetail>();
}
