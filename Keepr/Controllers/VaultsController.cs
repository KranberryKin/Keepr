using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Keepr.Services;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class VaultsController : ControllerBase
        {
            private readonly VaultsService _vs;

        public VaultsController(VaultsService vs)
        {
          _vs = vs;
        }

        [HttpGet]
        public ActionResult<List<Vault>> Get()
        {
            try
            {
                 return Ok( _vs.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{vaultId}")]
        public async Task<ActionResult<Vault>> Get(int vaultId)
        {
            try
            {
                  Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                  if (userInfo == null)
                  {
                      return Ok(_vs.Get(vaultId));
                  }
                  var vault = _vs.GetValid(vaultId);
                  if (vault.IsPrivate == true && userInfo.Id != vault.CreatorId)
                  {
                      if (vault.CreatorId != userInfo.Id)
                      {
                        return BadRequest("Can't Do That!");
                      }
                  }
                 return Ok(vault);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{vaultId}/keeps")]
        public ActionResult<List<VaultKeepView>> GetVaultKeeps(int vaultId)
        {
            try
            {
                 return Ok(_vs.GetVaultsKeeps(vaultId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
        {
            try
            {
                  Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                  vaultData.CreatorId = userInfo.Id;
                 var vault = _vs.Create(vaultData);
                 return Ok(vault);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]

        [HttpPut("{vaultId}")]
        public async Task<ActionResult<Vault>> Edit(int vaultId, [FromBody] Vault vaultData)
        {
            try
            {
                  Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                  vaultData.Id = vaultId;
                 var vault = _vs.Edit(vaultData, userInfo.Id);
                 return Ok(vault);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]

        [HttpDelete("{vaultId}")]
        public async Task<ActionResult<String>> Delete(int vaultId)
        {
            try
            {
                  Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vs.Delete(vaultId, userInfo.Id);
                 return Ok("Vault Deleted!");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}