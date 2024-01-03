using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoggoDollars.WebAPI.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var transactions = await _transactionService.GetAsync();

        if (transactions.Any())
            return Ok(transactions);
        else
            return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TransactionRequest transaction)
    {
        await _transactionService.PostAsync(transaction);
        return Ok();
    }
}
