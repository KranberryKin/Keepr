using System.Collections.Generic;
using Keepr.Interfaces;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService : IService<VaultKeep>
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    public VaultKeep Create(VaultKeep data)
    {
      return _vkr.Create(data);
    }

    public void Delete(int id, string userId)
    {
      var foundVaultKeep = Get(id);
      if (foundVaultKeep.CreatorId != userId)
      {
        throw new System.Exception("You can't delete this!");
      }
      _vkr.Delete(id);
    }

    public VaultKeep Edit(VaultKeep data, string userId)
    {
      var foundVaultKeep = Get(data.Id);
      if (foundVaultKeep.CreatorId != userId)
      {
        throw new System.Exception("You can't edit this!");
      }
      foundVaultKeep.VaultId = data.VaultId | foundVaultKeep.VaultId;
      return _vkr.Edit(foundVaultKeep);
    }

    public List<VaultKeep> Get()
    {
      return _vkr.Get();
    }

    public VaultKeep Get(int id)
    {
      var vaultKeep = _vkr.Get(id);
      if (vaultKeep == null)
      {
        throw new System.Exception("Can't find vaultkeep");
      }
      return vaultKeep;
    }
  }
}