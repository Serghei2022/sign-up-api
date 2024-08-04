using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sign_up_api.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }

    public required Guid CompanyId { get; set; }
    
    public required Company? Company { get; set; }

    public User()
    {  
    }

    [SetsRequiredMembers]
    public User(Guid id, Guid companyId, string firstname,
                string lastname, string username, 
                string password, string email)
    {
        Id = id;
        CompanyId = companyId;
        FirstName = firstname;
        LastName = lastname;
        UserName = username;
        Password = password;
        Email = email;
    }
}
