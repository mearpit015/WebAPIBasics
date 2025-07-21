using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPIBasics.Model;

public class TblCrudRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
}


public class TblCrudUpdate
{
    public string? Name { get; set; }

    public string? Email { get; set; }
}