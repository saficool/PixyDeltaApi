using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PixyDeltaApi.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(255)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(255)]
    public string? LastName { get; set; }
}
