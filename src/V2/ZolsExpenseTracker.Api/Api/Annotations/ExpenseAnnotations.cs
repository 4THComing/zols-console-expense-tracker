using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Api.DTOs.Expenses;

public class ExpenseAnnotations
{
    [Required]
    public string? VendorName { get; set; }

    [Required]
    public CategorySelection Category { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool IsExpense { get; set; }

    public string? Notes { get; set; }
    public void CreateExpenseDTO(string? vendorName, CategorySelection category, string? description, double amount, DateTime date, bool isExpense, string? notes)
    {
        VendorName = vendorName;
        Category = category;
        Description = description;
        Amount = amount;
        Date = date;
        IsExpense = isExpense;
        Notes = notes;

      
        if (string.IsNullOrWhiteSpace(vendorName))
            throw new ArgumentException("Vendor name is required.");

        if (category == default(CategorySelection))
            throw new ArgumentException("Category is required.");

        if (category == CategorySelection.None)
            throw new ArgumentException("Category is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be higher than 0.00");

        if (date == DateTime.MinValue)
            throw new ArgumentException("Date is required.");

        if (date != DateTime.MinValue && date > DateTime.Now)
            throw new ArgumentException("Date cannot be in the future.");

        if (date != DateTime.MinValue && date < DateTime.Now.AddYears(-1))
            throw new ArgumentException("Date cannot be more than a year in the past.");

        if (date != DateTime.MinValue && date.DayOfWeek == DayOfWeek.Sunday)
            throw new ArgumentException("Date cannot be on a Sunday.");

        if (date != DateTime.MinValue && date > DateTime.Now.AddDays(30))
            throw new ArgumentException("Date cannot be more than 30 days in the future..");
    }

    public void UpdateExpenseDTO(CategorySelection category, string? description, double amount, DateTime date, bool isExpense, string? vendorName, string? notes)
    {
        Category = category;
        Description = description;
        Amount = amount;
        Date = date;
        IsExpense = isExpense;
        VendorName = vendorName;
        Notes = notes;

        if (string.IsNullOrWhiteSpace(vendorName))
            throw new ArgumentException("Vendor name is required.");

        if (category == default(CategorySelection))
            throw new ArgumentException("Category is required.");

        if (category == CategorySelection.None)
            throw new ArgumentException("Category is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be higher than 0.00");

        if (date == DateTime.MinValue)
            throw new ArgumentException("Date is required.");

        if (date != DateTime.MinValue && date > DateTime.Now)
            throw new ArgumentException("Date cannot be in the future.");

        if (date != DateTime.MinValue && date < DateTime.Now.AddYears(-1))
            throw new ArgumentException("Date cannot be more than a year in the past.");

        if (date != DateTime.MinValue && date.DayOfWeek == DayOfWeek.Sunday)
            throw new ArgumentException("Date cannot be on a Sunday.");

        if (date != DateTime.MinValue && date > DateTime.Now.AddDays(30))
            throw new ArgumentException("Date cannot be more than 30 days in the future..");
    }
}