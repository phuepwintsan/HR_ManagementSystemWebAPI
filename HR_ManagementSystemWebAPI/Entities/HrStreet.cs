using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Street")]
public partial class HrStreet
{
    [Key]
    public int StreetId { get; set; }

    [StringLength(200)]
    public string? StreetName { get; set; }

    [Column("StreetName_MM")]
    [StringLength(200)]
    public string? StreetNameMm { get; set; }

    public int TownshipId { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }
}
