using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[Table("HR_Activity_Changes")]
public partial class HrActivityChange
{
    [Key]
    public long Id { get; set; }

    [StringLength(256)]
    public string? Title { get; set; }

    public string? Changes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ChangesOn { get; set; }

    [StringLength(256)]
    public string? ChangesBy { get; set; }

    [StringLength(50)]
    public string? ChangesState { get; set; }
}
