using System.Collections.Generic;
using System.Data;
using Keepr.Interfaces;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository : IRepository<VaultKeep>
  {
      private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeep Create(int id)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public VaultKeep Edit(int id, VaultKeep data)
    {
      throw new System.NotImplementedException();
    }

    public List<VaultKeep> Get()
    {
      throw new System.NotImplementedException();
    }

    public VaultKeep Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}
