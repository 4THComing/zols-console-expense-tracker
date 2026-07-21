using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZolsExpenseTracker.Api.DTOs.Expenses;

public class UpdateExpenseDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public CategorySelection Category { get; set; }

    [Required]
    [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
    public string? Description { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public double Amount { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public bool IsExpense { get; set; }

    [Required]
    public string? VendorName { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
    public string? Notes { get; set; }
}