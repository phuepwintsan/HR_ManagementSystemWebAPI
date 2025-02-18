using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_State")]
public partial class HrState
{
    [Key]
    public int StateId { get; set; }

    [StringLength(200)]
    public string? StateName { get; set; }

    [Column("StateName_MM")]
    [StringLength(200)]
    public string? StateNameMm { get; set; }
}
