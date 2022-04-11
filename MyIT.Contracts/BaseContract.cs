using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class BaseContract
{
    [Key]
    public Guid Id { get; set; }
}