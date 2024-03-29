﻿using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoggoDollars.WebAPI.Controllers;

[ApiController]
[Route("accounts")]

public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccount account)
    {
        Account createdAccount = await _accountService.CreateAsync(account);

        return Created(nameof(CreateAsync), createdAccount);
    }

    [HttpPost("{id}/top-up")]
    public async Task<IActionResult> TopUpAsync(string id, [FromBody] TopUpAmount amount)
    {
        return Ok(await _accountService.TopUpAsync(id, amount.Amount));
    }
}
