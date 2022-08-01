using System;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<Account>> Edit(string id, [FromBody] Account accountData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        accountData.Id = id;

        Account updated = _accountService.Edit(accountData, userInfo);
        return Ok(updated);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}