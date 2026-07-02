using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.DTOs.Expenses;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseDbContext _context;

    public ExpenseController(ExpenseDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetAllExpenses()
    {
        return await _context.Expenses
            .Select(x => ExpenseToDTO(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDTO>> GetExpenseById(Guid id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return ExpenseToDTO(expense);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> PutExpense(Guid id, ExpenseDTO expenseDTO)
    {
        if (id != expenseDTO.Id)
        {
            return BadRequest();
        }

        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        expense.Category = expenseDTO.Category;
        expense.Description = expenseDTO.Description;
        expense.Amount = expenseDTO.Amount;
        expense.Date = expenseDTO.Date;
        expense.IsExpense = expenseDTO.IsExpense;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!ExpenseExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDTO>> PostExpense(ExpenseDTO expenseDTO)
    {
        var expense = new Expense
        {
            Category = expenseDTO.Category,
            Description = expenseDTO.Description,
            Amount = expenseDTO.Amount,
            Date = expenseDTO.Date,
            IsExpense = expenseDTO.IsExpense
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetExpenseById),
            new { id = expense.Id },
            ExpenseToDTO(expense));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpense(Guid id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExpenseExists(Guid id)
    {
        return _context.Expenses.Any(e => e.Id == id);
    }

    private static ExpenseDTO ExpenseToDTO(Expense expense) =>
      new ExpenseDTO
      {
          Id = expense.Id,
          Category = expense.Category,
          Description = expense.Description,
          Amount = expense.Amount,
          Date = expense.Date,
          IsExpense = expense.IsExpense
      };
}