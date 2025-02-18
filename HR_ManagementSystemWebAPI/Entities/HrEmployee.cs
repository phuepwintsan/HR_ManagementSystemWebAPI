using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Employee")]
public partial class HrEmployee
{
    [Key]
    [StringLength(256)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(50)]
    public string? Code { get; set; }

    [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime JoinDate { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [Column("NRC")]
    [StringLength(50)]
    public string? Nrc { get; set; }

    [StringLength(256)]
    public string? Qualification { get; set; }

    [StringLength(256)]
    public string? Education { get; set; }

    [StringLength(256)]
    public string? OtherPhone { get; set; }

    [StringLength(256)]
    public string? HouseNo { get; set; }

    public int? StreetId { get; set; }

    [StringLength(256)]
    public string? StreetName { get; set; }

    public int? TownshipId { get; set; }

    public int? StateId { get; set; }

    [StringLength(256)]
    public string? Profile { get; set; }

    [StringLength(256)]
    public string? FingerPrint { get; set; }

    [StringLength(50)]
    public string? FingerPrintNo { get; set; }

    [StringLength(256)]
    public string? DrivingLicense { get; set; }

    public bool IsSignAgreement { get; set; }

    public DateOnly? ResignDate { get; set; }

    public double Salary { get; set; }

    [StringLength(3)]
    public string? Currency { get; set; }

    public double LoanAmt { get; set; }

    public int Status { get; set; }

    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    public long BranchId { get; set; }

    public long? DeptId { get; set; }

    public long? PositionId { get; set; }

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

    [InverseProperty("Employee")]
    public virtual ICollection<HrAttendance> HrAttendances { get; set; } = new List<HrAttendance>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeAllowance> HrEmployeeAllowances { get; set; } = new List<HrEmployeeAllowance>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeBacker> HrEmployeeBackers { get; set; } = new List<HrEmployeeBacker>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeDailyReport> HrEmployeeDailyReports { get; set; } = new List<HrEmployeeDailyReport>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeDeduction> HrEmployeeDeductions { get; set; } = new List<HrEmployeeDeduction>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeDocument> HrEmployeeDocuments { get; set; } = new List<HrEmployeeDocument>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeEducation> HrEmployeeEducations { get; set; } = new List<HrEmployeeEducation>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeHistory> HrEmployeeHistories { get; set; } = new List<HrEmployeeHistory>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeJobHistory> HrEmployeeJobHistories { get; set; } = new List<HrEmployeeJobHistory>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeQualification> HrEmployeeQualifications { get; set; } = new List<HrEmployeeQualification>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeRequest> HrEmployeeRequests { get; set; } = new List<HrEmployeeRequest>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeSchedule> HrEmployeeSchedules { get; set; } = new List<HrEmployeeSchedule>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrJobApplicant> HrJobApplicants { get; set; } = new List<HrJobApplicant>();

    [InverseProperty("Employee")]
    public virtual ICollection<HrPaySlip> HrPaySlips { get; set; } = new List<HrPaySlip>();
}
