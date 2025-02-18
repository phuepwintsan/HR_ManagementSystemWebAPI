using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrStreet
{
    public int StreetId { get; set; }

    [StringLength(200)]
    public string? StreetName { get; set; }

    [Column("StreetName_MM")]
    [StringLength(200)]
    public string? StreetNameMm { get; set; }

    public int TownshipId { get; set; }

    [StringLength(200)]
    public string? TownshipName { get; set; }

    [Column("TownshipName_MM")]
    [StringLength(200)]
    public string? TownshipNameMm { get; set; }

    public int StateId { get; set; }

    [StringLength(200)]
    public string? StateName { get; set; }

    [Column("StateName_MM")]
    [StringLength(200)]
    public string? StateNameMm { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }
}
