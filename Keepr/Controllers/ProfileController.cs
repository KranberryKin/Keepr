using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
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

    [HttpGet("{profileId}")]
    public ActionResult<Profile> Get(string profileId){
        try
        {
             return Ok(_ps.Get(profileId));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetKeeps(string profileId){
        try
        {
             return Ok(_ps.GetKeeps(profileId));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaults(string profileId){
        try
        {
             Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            if (userInfo == null || userInfo.Id != profileId)
            {
                return Ok(_ps.GetVaults(profileId));
            }
             return Ok(_ps.GetValidVaults(profileId));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    }
} 
