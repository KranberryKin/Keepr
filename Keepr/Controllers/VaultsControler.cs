using System;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Keepr.Services;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;

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
                 var vaults = _vs.Get();
                 return Ok(vaults);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{vaultId}")]
        public ActionResult<Vault> Get(int vaultId)
        {
            try
            {
                 var vault = _vs.Get(vaultId);
                 return Ok(vault);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

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
                throw new Exception(e.Message);
            }
        }

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
                throw new Exception(e.Message);
            }
        }

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
                throw new Exception(e.Message);
            }
        }
    }
}