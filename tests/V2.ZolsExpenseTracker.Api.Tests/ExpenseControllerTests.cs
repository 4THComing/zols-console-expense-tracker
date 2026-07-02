using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ZolsExpenseTracker.Api.Models;
using ZolsExpenseTracker.Api.Controllers;
using ZolsExpenseTracker.Api.DTOs.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace V2.ZolsExpenseTracker.Api.Tests
{
    public class ExpenseControllerTests
    {
        private ExpenseDbContext CreateInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            return new ExpenseDbContext(options);
        }

        [Fact]
        public async Task Post_Get_Put_Delete_FullFlow()
        {
            var context = CreateInMemoryContext("PostGetPutDelete");
            var controller = new ExpenseController(context);

            // Ensure empty
            var initial = await controller.GetAllExpenses();
            Assert.NotNull(initial.Value);
            Assert.Empty(initial.Value);

            // Create
            var dto = new ExpenseDTO
            {
                Category = CategorySelection.Food,
                Description = "Lunch",
                Amount = 12.50,
                Date = DateTime.UtcNow,
                IsExpense = true
            };

            var postResult = await controller.PostExpense(dto);
            var createdAction = Assert.IsType<CreatedAtActionResult>(postResult.Result);
            var createdDto = Assert.IsType<ExpenseDTO>(createdAction.Value);
            Assert.Equal(dto.Description, createdDto.Description);

            // Get by id
            var getById = await controller.GetExpenseById(createdDto.Id);
            Assert.NotNull(getById.Value);
            Assert.Equal(createdDto.Id, getById.Value.Id);

            // Update
            createdDto.Description = "Lunch at cafe";
            createdDto.Amount = 15.00;
            var putResult = await controller.PutExpense(createdDto.Id, createdDto);
            Assert.IsType<NoContentResult>(putResult);

            var afterUpdate = await controller.GetExpenseById(createdDto.Id);
            Assert.Equal("Lunch at cafe", afterUpdate.Value.Description);
            Assert.Equal(15.00, afterUpdate.Value.Amount);

            // Delete
            var deleteResult = await controller.DeleteExpense(createdDto.Id);
            Assert.IsType<NoContentResult>(deleteResult);

            var afterDelete = await controller.GetExpenseById(createdDto.Id);
            Assert.IsType<NotFoundResult>(afterDelete.Result);
        }
    }
}
