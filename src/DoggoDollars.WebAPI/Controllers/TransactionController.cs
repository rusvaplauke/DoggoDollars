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
}
