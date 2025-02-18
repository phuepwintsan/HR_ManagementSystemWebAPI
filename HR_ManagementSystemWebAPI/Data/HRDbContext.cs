using System;
using System.Collections.Generic;
using HR_ManagementSystemWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Data;

public partial class HRDbContext : DbContext
{
    public HRDbContext(DbContextOptions<HRDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<HrActivityChange> HrActivityChanges { get; set; }

    public virtual DbSet<HrAllowance> HrAllowances { get; set; }

    public virtual DbSet<HrAnnouncement> HrAnnouncements { get; set; }

    public virtual DbSet<HrAttendance> HrAttendances { get; set; }

    public virtual DbSet<HrBranch> HrBranches { get; set; }

    public virtual DbSet<HrCompany> HrCompanies { get; set; }

    public virtual DbSet<HrDailyReportTitle> HrDailyReportTitles { get; set; }

    public virtual DbSet<HrDeduction> HrDeductions { get; set; }

    public virtual DbSet<HrDepartment> HrDepartments { get; set; }

    public virtual DbSet<HrEmployee> HrEmployees { get; set; }

    public virtual DbSet<HrEmployeeAllowance> HrEmployeeAllowances { get; set; }

    public virtual DbSet<HrEmployeeBacker> HrEmployeeBackers { get; set; }

    public virtual DbSet<HrEmployeeBank> HrEmployeeBanks { get; set; }

    public virtual DbSet<HrEmployeeDailyReport> HrEmployeeDailyReports { get; set; }

    public virtual DbSet<HrEmployeeDailyReportDetail> HrEmployeeDailyReportDetails { get; set; }

    public virtual DbSet<HrEmployeeDeduction> HrEmployeeDeductions { get; set; }

    public virtual DbSet<HrEmployeeDocument> HrEmployeeDocuments { get; set; }

    public virtual DbSet<HrEmployeeEducation> HrEmployeeEducations { get; set; }

    public virtual DbSet<HrEmployeeHistory> HrEmployeeHistories { get; set; }

    public virtual DbSet<HrEmployeeJobHistory> HrEmployeeJobHistories { get; set; }

    public virtual DbSet<HrEmployeePaymentVoucher> HrEmployeePaymentVouchers { get; set; }

    public virtual DbSet<HrEmployeeQualification> HrEmployeeQualifications { get; set; }

    public virtual DbSet<HrEmployeeRequest> HrEmployeeRequests { get; set; }

    public virtual DbSet<HrEmployeeSchedule> HrEmployeeSchedules { get; set; }

    public virtual DbSet<HrJobApplicant> HrJobApplicants { get; set; }

    public virtual DbSet<HrJobOpening> HrJobOpenings { get; set; }

    public virtual DbSet<HrLeaveGroup> HrLeaveGroups { get; set; }

    public virtual DbSet<HrLeaveType> HrLeaveTypes { get; set; }

    public virtual DbSet<HrLoanType> HrLoanTypes { get; set; }

    public virtual DbSet<HrNotificationToken> HrNotificationTokens { get; set; }

    public virtual DbSet<HrPaySlip> HrPaySlips { get; set; }

    public virtual DbSet<HrPermission> HrPermissions { get; set; }

    public virtual DbSet<HrPolicy> HrPolicies { get; set; }

    public virtual DbSet<HrPosition> HrPositions { get; set; }

    public virtual DbSet<HrRule> HrRules { get; set; }

    public virtual DbSet<HrState> HrStates { get; set; }

    public virtual DbSet<HrStreet> HrStreets { get; set; }

    public virtual DbSet<HrTownship> HrTownships { get; set; }

    public virtual DbSet<TokenClaim> TokenClaims { get; set; }

    public virtual DbSet<ViHrAllowance> ViHrAllowances { get; set; }

    public virtual DbSet<ViHrAnnouncement> ViHrAnnouncements { get; set; }

    public virtual DbSet<ViHrAttendance> ViHrAttendances { get; set; }

    public virtual DbSet<ViHrBranch> ViHrBranches { get; set; }

    public virtual DbSet<ViHrCompany> ViHrCompanies { get; set; }

    public virtual DbSet<ViHrDailyReportTitle> ViHrDailyReportTitles { get; set; }

    public virtual DbSet<ViHrDeduction> ViHrDeductions { get; set; }

    public virtual DbSet<ViHrDepartment> ViHrDepartments { get; set; }

    public virtual DbSet<ViHrEmployee> ViHrEmployees { get; set; }

    public virtual DbSet<ViHrEmployeeAllowance> ViHrEmployeeAllowances { get; set; }

    public virtual DbSet<ViHrEmployeeDailyReport> ViHrEmployeeDailyReports { get; set; }

    public virtual DbSet<ViHrEmployeeDeduction> ViHrEmployeeDeductions { get; set; }

    public virtual DbSet<ViHrEmployeeHistory> ViHrEmployeeHistories { get; set; }

    public virtual DbSet<ViHrEmployeeLeaveRequest> ViHrEmployeeLeaveRequests { get; set; }

    public virtual DbSet<ViHrEmployeeLoanRequest> ViHrEmployeeLoanRequests { get; set; }

    public virtual DbSet<ViHrEmployeeRequest> ViHrEmployeeRequests { get; set; }

    public virtual DbSet<ViHrEmployeeResignRequest> ViHrEmployeeResignRequests { get; set; }

    public virtual DbSet<ViHrEmployeeSchedule> ViHrEmployeeSchedules { get; set; }

    public virtual DbSet<ViHrJobOpening> ViHrJobOpenings { get; set; }

    public virtual DbSet<ViHrLeaveGroup> ViHrLeaveGroups { get; set; }

    public virtual DbSet<ViHrLeaveType> ViHrLeaveTypes { get; set; }

    public virtual DbSet<ViHrLoanType> ViHrLoanTypes { get; set; }

    public virtual DbSet<ViHrPaySlip> ViHrPaySlips { get; set; }

    public virtual DbSet<ViHrPosition> ViHrPositions { get; set; }

    public virtual DbSet<ViHrRule> ViHrRules { get; set; }

    public virtual DbSet<ViHrStreet> ViHrStreets { get; set; }

    public virtual DbSet<ViHrTownship> ViHrTownships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<HrAllowance>(entity =>
        {
            entity.HasKey(e => e.AllowanceId).HasName("PK_Allowance");
        });

        modelBuilder.Entity<HrAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendId).HasName("PK_HR_Attendace");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrAttendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Attendance_HR_Employee");
        });

        modelBuilder.Entity<HrBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK_Branch_1");

            entity.HasOne(d => d.Company).WithMany(p => p.HrBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Branch_HR_Company");
        });

        modelBuilder.Entity<HrCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_Company");
        });

        modelBuilder.Entity<HrDailyReportTitle>(entity =>
        {
            entity.HasKey(e => e.ReportTitleId).HasName("PK_VI_HR_DailyReportTitle");
        });

        modelBuilder.Entity<HrDeduction>(entity =>
        {
            entity.HasKey(e => e.DeductionId).HasName("PK_Deduction");
        });

        modelBuilder.Entity<HrDepartment>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK_Department_1");

            entity.HasOne(d => d.Branch).WithMany(p => p.HrDepartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Department_HR_Branch");

            entity.HasOne(d => d.LeaveGroup).WithMany(p => p.HrDepartments).HasConstraintName("FK_HR_Department_HR_LeaveGroup");
        });

        modelBuilder.Entity<HrEmployee>(entity =>
        {
            entity.Property(e => e.Currency).IsFixedLength();
            entity.Property(e => e.Gender).IsFixedLength();
        });

        modelBuilder.Entity<HrEmployeeAllowance>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeAllowances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Allowance_HR_Employee");

            entity.HasOne(d => d.PaySlip).WithMany(p => p.HrEmployeeAllowances).HasConstraintName("FK_HR_Employee_Allowance_HR_PaySlip");
        });

        modelBuilder.Entity<HrEmployeeBacker>(entity =>
        {
            entity.Property(e => e.BackerId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeBackers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Backer_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeDailyReport>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeDailyReports).HasConstraintName("FK_HR_Employee_Daily_Report_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeDailyReportDetail>(entity =>
        {
            entity.HasOne(d => d.Report).WithMany(p => p.HrEmployeeDailyReportDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Daily_Report_Detail_HR_Employee_Daily_Report");

            entity.HasOne(d => d.Title).WithMany(p => p.HrEmployeeDailyReportDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Daily_Report_Detail_HR_DailyReportTitle");
        });

        modelBuilder.Entity<HrEmployeeDeduction>(entity =>
        {
            entity.HasOne(d => d.Deduction).WithMany(p => p.HrEmployeeDeductions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Deduction_HR_Deduction");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeDeductions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Deduction_HR_Employee");

            entity.HasOne(d => d.PaySlip).WithMany(p => p.HrEmployeeDeductions).HasConstraintName("FK_HR_Employee_Deduction_HR_PaySlip");
        });

        modelBuilder.Entity<HrEmployeeDocument>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Document_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeEducation>(entity =>
        {
            entity.HasKey(e => e.EducationHistoryId).HasName("PK__HR_Emplo__576CCAED231ABC5E");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeEducations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Education_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK_HR_Employe_History");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_History_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeJobHistory>(entity =>
        {
            entity.HasKey(e => e.JobHistoryId).HasName("PK__HR_Emplo__A809D914580F39F3");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeJobHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_JobHistory_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeQualification>(entity =>
        {
            entity.HasKey(e => e.QualificationId).HasName("PK__Employee__C95C128A0792E1BC");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeQualifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Employee_Qualification_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeRequest>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeRequests).HasConstraintName("FK_HR_Employee_Request_HR_Employee");
        });

        modelBuilder.Entity<HrEmployeeSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK_HR_Employe_Schedule");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeSchedules).HasConstraintName("FK_HR_Employee_Schedule_HR_Employee");
        });

        modelBuilder.Entity<HrJobApplicant>(entity =>
        {
            entity.HasKey(e => e.ApplyId).HasName("PK_HR_Job_Recruitment");

            entity.Property(e => e.Gender).IsFixedLength();

            entity.HasOne(d => d.Employee).WithMany(p => p.HrJobApplicants).HasConstraintName("FK_HR_Job_Applicant_HR_Employee");

            entity.HasOne(d => d.Job).WithMany(p => p.HrJobApplicants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Job_Applicant_HR_Job_Opening");
        });

        modelBuilder.Entity<HrLeaveGroup>(entity =>
        {
            entity.HasOne(d => d.Branch).WithMany(p => p.HrLeaveGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_LeaveGroup_HR_Branch");

            entity.HasOne(d => d.Company).WithMany(p => p.HrLeaveGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_LeaveGroup_HR_Company");
        });

        modelBuilder.Entity<HrLeaveType>(entity =>
        {
            entity.HasOne(d => d.LeaveGroup).WithMany(p => p.HrLeaveTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_LeaveType_HR_LeaveGroup");
        });

        modelBuilder.Entity<HrLoanType>(entity =>
        {
            entity.HasOne(d => d.Company).WithMany(p => p.HrLoanTypes).HasConstraintName("FK_HR_LoanType_HR_Company");
        });

        modelBuilder.Entity<HrPaySlip>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.HrPaySlips).HasConstraintName("FK_HR_PaySlip_HR_Employee");
        });

        modelBuilder.Entity<HrPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK_Position");

            entity.HasOne(d => d.Dept).WithMany(p => p.HrPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Position_HR_Department");
        });

        modelBuilder.Entity<HrRule>(entity =>
        {
            entity.Property(e => e.RuleId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Deduction).WithMany(p => p.HrRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HR_Rule_HR_Deduction");
        });

        modelBuilder.Entity<HrState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK_State");

            entity.Property(e => e.StateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HrStreet>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PK_Street");

            entity.Property(e => e.StreetId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HrTownship>(entity =>
        {
            entity.HasKey(e => e.TownshipId).HasName("PK_Township");

            entity.Property(e => e.TownshipId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ViHrAllowance>(entity =>
        {
            entity.ToView("VI_HR_Allowance");
        });

        modelBuilder.Entity<ViHrAnnouncement>(entity =>
        {
            entity.ToView("VI_HR_Announcement");
        });

        modelBuilder.Entity<ViHrAttendance>(entity =>
        {
            entity.ToView("VI_HR_Attendance");

            entity.Property(e => e.Gender).IsFixedLength();
        });

        modelBuilder.Entity<ViHrBranch>(entity =>
        {
            entity.ToView("VI_HR_Branch");
        });

        modelBuilder.Entity<ViHrCompany>(entity =>
        {
            entity.ToView("VI_HR_Company");
        });

        modelBuilder.Entity<ViHrDailyReportTitle>(entity =>
        {
            entity.ToView("VI_HR_DailyReportTitle");
        });

        modelBuilder.Entity<ViHrDeduction>(entity =>
        {
            entity.ToView("VI_HR_Deduction");
        });

        modelBuilder.Entity<ViHrDepartment>(entity =>
        {
            entity.ToView("VI_HR_Department");
        });

        modelBuilder.Entity<ViHrEmployee>(entity =>
        {
            entity.ToView("VI_HR_Employee");

            entity.Property(e => e.Currency).IsFixedLength();
            entity.Property(e => e.Gender).IsFixedLength();
        });

        modelBuilder.Entity<ViHrEmployeeAllowance>(entity =>
        {
            entity.ToView("VI_HR_Employee_Allowance");
        });

        modelBuilder.Entity<ViHrEmployeeDailyReport>(entity =>
        {
            entity.ToView("VI_HR_Employee_Daily_Report");
        });

        modelBuilder.Entity<ViHrEmployeeDeduction>(entity =>
        {
            entity.ToView("VI_HR_Employee_Deduction");
        });

        modelBuilder.Entity<ViHrEmployeeHistory>(entity =>
        {
            entity.ToView("VI_HR_Employee_History");
        });

        modelBuilder.Entity<ViHrEmployeeLeaveRequest>(entity =>
        {
            entity.ToView("VI_HR_Employee_Leave_Request");
        });

        modelBuilder.Entity<ViHrEmployeeLoanRequest>(entity =>
        {
            entity.ToView("VI_HR_Employee_Loan_Request");
        });

        modelBuilder.Entity<ViHrEmployeeRequest>(entity =>
        {
            entity.ToView("VI_HR_Employee_Request");
        });

        modelBuilder.Entity<ViHrEmployeeResignRequest>(entity =>
        {
            entity.ToView("VI_HR_Employee_Resign_Request");
        });

        modelBuilder.Entity<ViHrEmployeeSchedule>(entity =>
        {
            entity.ToView("VI_HR_Employee_Schedule");
        });

        modelBuilder.Entity<ViHrJobOpening>(entity =>
        {
            entity.ToView("VI_HR_Job_Opening");
        });

        modelBuilder.Entity<ViHrLeaveGroup>(entity =>
        {
            entity.ToView("VI_HR_LeaveGroup");
        });

        modelBuilder.Entity<ViHrLeaveType>(entity =>
        {
            entity.ToView("VI_HR_LeaveType");
        });

        modelBuilder.Entity<ViHrLoanType>(entity =>
        {
            entity.ToView("VI_HR_Loan_Type");
        });

        modelBuilder.Entity<ViHrPaySlip>(entity =>
        {
            entity.ToView("VI_HR_PaySlip");
        });

        modelBuilder.Entity<ViHrPosition>(entity =>
        {
            entity.ToView("VI_HR_Position");
        });

        modelBuilder.Entity<ViHrRule>(entity =>
        {
            entity.ToView("VI_HR_Rule");
        });

        modelBuilder.Entity<ViHrStreet>(entity =>
        {
            entity.ToView("VI_HR_Street");
        });

        modelBuilder.Entity<ViHrTownship>(entity =>
        {
            entity.ToView("VI_HR_Township");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
