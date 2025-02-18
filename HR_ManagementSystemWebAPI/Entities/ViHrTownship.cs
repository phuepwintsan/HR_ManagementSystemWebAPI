using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Keyless]
public partial class ViHrTownship
{
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
}
