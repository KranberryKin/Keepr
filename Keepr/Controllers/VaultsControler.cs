using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keepr.Controllers
{
  public partial class AccountController
  {
    public class VaultsControler : ControllerBase
        {
            [HttpGet]
            public ActionResult<List<Vault>> Get(){
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


}