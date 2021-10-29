using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
        {
            [HttpGet]
            public ActionResult<List<VaultKeep>> Get(){
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