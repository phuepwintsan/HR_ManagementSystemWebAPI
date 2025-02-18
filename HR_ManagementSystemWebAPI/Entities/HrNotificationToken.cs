using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR_ManagementSystemWebAPI.Entities;

[PrimaryKey("UserId", "Device")]
[Table("HR_Notification_Token")]
public partial class HrNotificationToken
{
    [Key]
    [StringLength(50)]
    public string UserId { get; set; } = null!;

    [Key]
    [StringLength(100)]
    public string Device { get; set; } = null!;

    [StringLength(256)]
    public string Token { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }
}
