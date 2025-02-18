using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrCompany
{
    [StringLength(5)]
    public string CompanyId { get; set; } = null!;

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public DateOnly? JoinDate { get; set; }

    [StringLength(256)]
    public string? LicenseNo { get; set; }

    [StringLength(256)]
    public string? ContactPerson { get; set; }

    [StringLength(256)]
    public string? PrimaryPhone { get; set; }

    [StringLength(256)]
    public string? OtherPhone { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? HouseNo { get; set; }

    public int? StreetId { get; set; }

    [StringLength(256)]
    public string? StreetName { get; set; }

    public int? TownshipId { get; set; }

    [StringLength(200)]
    public string? TownshipName { get; set; }

    public int? StateId { get; set; }

    [StringLength(200)]
    public string? StateName { get; set; }

    [StringLength(256)]
    public string? Photo { get; set; }

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
}
