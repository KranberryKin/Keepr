using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Keepr.Services;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
        {
          private readonly KeepsService _ks;

      public KeepsController(KeepsService ks)
      {
        _ks = ks;
      }

            [HttpGet]
            public ActionResult<List<Keep>> Get()
            {
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

            [HttpGet("{keepId}")]
            public ActionResult<Keep> Get(int keepId)
            {
              try
              {
                   var keep = _ks.Get(keepId);
                   return Ok(keep);
              }
              catch (System.Exception e)
              {
                  throw new Exception(e.Message);
              }
            }

            [HttpPost]
            public async Task<ActionResult<Keep>> Create([FromBody] Keep keepdata)
            {
              try
              {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                keepdata.CreatorId = userInfo.Id;
                   var keep = _ks.Create(keepdata);
                   return Ok(keep);
              }
              catch (System.Exception e)
              {
                  throw new Exception(e.Message);
              }
            }

            [HttpPut("{keepId}")]
            public async Task<ActionResult<Keep>> Edit(int keepId, [FromBody] Keep keepdata)
            {
              try
              {
                   Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                   keepdata.CreatorId = userInfo.Id;
                   keepdata.Id = keepId;
                   var keep = _ks.Edit(keepdata);
                   return Ok(keep);
              }
              catch (System.Exception e)
              {
                  throw new Exception(e.Message);
              }
            }

            [HttpDelete("{keepId}")]
            public async Task<ActionResult<String>> Delete(int keepId)
            {
              try
              {
                  Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                   _ks.Delete(keepId, userInfo.Id);
                   return Ok("Keep Deleted");
              }
              catch (System.Exception e)
              {
                  throw new Exception(e.Message);
              }
            }
    }

}