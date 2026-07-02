namespace ZolsExpenseTracker.Api.DTOs.Expenses;

public class CreateExpenseDTO
{
    public CategorySelection Category { get; set; }

    public string? Description { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public bool IsExpense { get; set; }
}