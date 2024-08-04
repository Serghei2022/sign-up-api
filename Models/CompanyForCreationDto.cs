namespace sign_up_api.Models;

public class CompanyForCreationDto
{
    public required string Name { get; set; }
    public Guid IndustryId { get; set; }
}
