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
    public class VaultKeepsController : ControllerBase
        {
            private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet]
            public ActionResult<List<VaultKeep>> Get(){
                try
                {
                     return Ok(_vks.Get());
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            [HttpGet("{vaultkeepId}")]
            public ActionResult<VaultKeep> Get(int vaultkeepId)
            {
                try
                {
                     return Ok(_vks.Get(vaultkeepId));
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                     
                }
            }

            [HttpPost]
            public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
            {
                try
                {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vaultKeepData.CreatorId = userInfo.Id;
                     return Ok(_vks.Create(vaultKeepData));
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                     
                }
            }

            [HttpPut("{vaultkeepId}")]
            public async Task<ActionResult<VaultKeep>> Edit(int vaultkeepId, [FromBody] VaultKeep vaultKeepData)
            {
                try
                {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vaultKeepData.Id = vaultkeepId;
                     return Ok(_vks.Edit(vaultKeepData, userInfo.Id));
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                     
                }
            }

            [HttpDelete("{vaultkeepId}")]
            public async Task<ActionResult<String>> Delete(int vaultkeepId)
            {
                try
                {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vks.Delete(vaultkeepId, userInfo.Id);
                     return Ok("Vaultkeep Deleted");
                }
                catch (System.Exception e)
                {
                    throw new Exception(e.Message);
                     
                }
            }
        }
}