using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<List<Profile>> Get()
    {
      try
      {
        List<Profile> profiles = _ps.Get();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(string id)
    {
      try
      {
        Profile profile = _ps.GetById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}