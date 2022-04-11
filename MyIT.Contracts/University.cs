using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class University : BaseContract
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string EmailDomain { get; set; }= string.Empty;
    
    [Required]
    public string Country { get; set; } = string.Empty;
    
    [Required]
    public string City { get; set; } = string.Empty;
    
    [Required]
    public string SiteUrl { get; set; } = string.Empty;

    public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}