using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PixyDeltaApi.Services;

namespace PixyDeltaApi.Models;

[Table("Notes")]
public class Notes
{
    [Key]
    [Required]
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public string? AddedBy { get; set; }
    public DateTime? AddedDate { get; set; }
    public string? UpdateddBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class AddNoteBindingModel
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public string? AddedBy { get; set; } = "";
    public DateTime? AddedDate { get; set; }
    public string? UpdateddBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class UpdateNoteBindingModel
{
    [Required]
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public string? AddedBy { get; set; } = "";
    public DateTime? AddedDate { get; set; }
    public string? UpdateddBy { get; set; } = "";
    public DateTime? UpdatedDate { get; set; }
}