using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
        {
            [HttpGet]
            public ActionResult<Profile> Get(){
                try
                {
                     return Ok();
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
}