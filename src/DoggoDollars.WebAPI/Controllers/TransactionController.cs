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
        return Ok(await _transactionService.GetAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Transaction transaction)
    {
        return Ok("Transaction in progress");
    }
}
