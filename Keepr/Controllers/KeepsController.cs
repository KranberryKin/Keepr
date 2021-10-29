using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Keepr.Services;

namespace Keepr.Controllers
{
  public partial class AccountController
  {
    public class KeepsController : ControllerBase
        {
          private readonly KeepsService _ks;

      public KeepsController(KeepsService ks)
      {
        _ks = ks;
      }

      [HttpGet]
            public ActionResult<List<Keep>> Get(){
                try
                {
                     var keeps = _ks.Get();
                     return Ok(keeps);
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }


}