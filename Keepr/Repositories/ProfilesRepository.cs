using System.Collections.Generic;
using System.Data;
using Keepr.Interfaces;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class ProfilesRepository : IRepository<Profile>
  {
      private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Profile Create(int id)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Profile Edit(int id, Profile data)
    {
      throw new System.NotImplementedException();
    }

    public List<Profile> Get()
    {
      throw new System.NotSupportedException("You want to what now?");
    }

    public Profile Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}
