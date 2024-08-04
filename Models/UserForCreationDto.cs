namespace sign_up_api.Models;

public class UserForCreationDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required Guid CompanyId { get; set; }

}
