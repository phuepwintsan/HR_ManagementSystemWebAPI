using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_DailyReportTitle")]
public partial class HrDailyReportTitle
{
    [Key]
    public long ReportTitleId { get; set; }

    public string? ReportTitle { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

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

    [InverseProperty("Title")]
    public virtual ICollection<HrEmployeeDailyReportDetail> HrEmployeeDailyReportDetails { get; set; } = new List<HrEmployeeDailyReportDetail>();
}
