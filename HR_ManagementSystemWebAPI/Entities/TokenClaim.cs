using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[PrimaryKey("UserId", "Device")]
[Table("Token_Claim")]
public partial class TokenClaim
{
    [Key]
    [StringLength(128)]
    public string UserId { get; set; } = null!;

    [Key]
    [StringLength(128)]
    public string Device { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? RefreshDate { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TokenExpiry { get; set; }
}
