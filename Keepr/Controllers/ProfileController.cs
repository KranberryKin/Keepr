using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
    {
    private readonly ProfilesService _ps;

    public ProfileController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<Profile> Get(){
        try
        {
             return Ok();
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    }
}