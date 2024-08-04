namespace sign_up_api.Models;

public class CompanyDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid IndustryId { get; set; }
}
