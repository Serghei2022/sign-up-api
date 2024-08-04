using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sign_up_api.Entities;

public class Company
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }
    public Guid IndustryId { get; set; }
    public Industry? Industry { get; set; }
    public ICollection<Industry> Industries { get; set; } = new List<Industry>();
    public ICollection<User> Users { get; set; } = new List<User>();

    public Company()
    {
    }

    [SetsRequiredMembers]
    public Company(Guid id, string name, Guid industryId)
    {
        Id = id;
        Name = name;
        IndustryId = industryId;
    }
}
