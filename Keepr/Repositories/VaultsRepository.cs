using System.Collections.Generic;
using System.Data;
using Keepr.Interfaces;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository : IRepository<Vault>
  {
      private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault Create(int id)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Vault Edit(int id, Vault data)
    {
      throw new System.NotImplementedException();
    }

    public List<Vault> Get()
    {
      throw new System.NotImplementedException();
    }

    public Vault Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}
