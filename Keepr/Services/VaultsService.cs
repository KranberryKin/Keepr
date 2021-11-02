using System.Collections.Generic;
using Keepr.Interfaces;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService : IService<Vault>
  {
    private readonly VaultsRepository _vr;

    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }

    public Vault Create(Vault data)
    {
      return _vr.Create(data);
    }

    public void Delete(int id, string userId)
    {
      var foundVault = Get(id);
      if (foundVault.CreatorId != userId)
      {
        throw new System.Exception("You can't delete this!");
      }
      _vr.Delete(id);
    }


    public Vault Edit(Vault data, string userId)
    {
      var foundVault = Get(data.Id);
      if (foundVault.CreatorId != userId)
      {
        throw new System.Exception("You Can't Edit This!");
      }
      foundVault.Name = data.Name ?? foundVault.Name;
      foundVault.Description = data.Description ?? foundVault.Description;
      foundVault.IsPrivate = data.IsPrivate ?? foundVault.IsPrivate;
      return _vr.Edit(foundVault);
    }

    public List<Vault> Get()
    {
      return _vr.Get();
    }

    public Vault Get(int id)
    {
      var foundVault = _vr.Get(id);
      if (foundVault == null)
      {
        throw new System.Exception("Can't find Vault");
      }
      return foundVault;
    }

    internal List<VaultKeepView> GetVaultsKeeps(int vaultId)
    {
      var foundVault = Get(vaultId);
      var vault = _vr.GetVaultsKeeps(foundVault.Id);
      return vault;
    }
  }
}