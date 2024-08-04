using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sign_up_api.Entities;

public class Industry 
{ 
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }
    public ICollection<Company> Companies { get; set; } = new List<Company>();
    public Industry()
    { 
    }

    [SetsRequiredMembers]
    public Industry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
