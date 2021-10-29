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
        throw new System.Exception("You Can't Delete This!");
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
      var vault = _vr.Get(id);
      if (vault == null)
      {
        throw new System.Exception("Can't Find Vault");
      }
      return vault;
    }
  }
}