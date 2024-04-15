using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels;

public class ProductViewModel
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Field 'Name' is required")]
    [MaxLength(100)]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Field 'Description' is required")]
    [MaxLength(2000)]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Field 'Price' is required")]
    [Range(1, 99999.99)]
    [Display(Name = "Price")]
    public decimal Price { get; set; }
}