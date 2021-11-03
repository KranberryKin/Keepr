using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

    public Profile Create(Profile data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Profile Edit(Profile data)
    {
      throw new System.NotImplementedException();
    }

    public List<Profile> Get()
    {
      throw new System.NotSupportedException("You want to what now?");
    }

    public Profile Get(string profileId)
    {
      string sql = "SELECT * FROM accounts WHERE id = @profileId";
      return _db.Query<Profile>(sql, new {profileId}).FirstOrDefault();
    }

    internal List<Keep> GetKeeps(string profileId)
    {
      string sql = "SELECT * FROM keeps WHERE creatorId = @profileId;";
      return _db.Query<Keep>(sql, new {profileId}).ToList();
    }

    internal List<Vault> GetValidVaults(string profileId)
    {
      string sql = "SELECT * FROM vaults WHERE creatorId = @profileId;";
      return _db.Query<Vault>(sql, new {profileId}).ToList();
    }

    internal List<Vault> GetVaults(string profileId)
    {
      string sql = "SELECT * FROM vaults WHERE creatorId = @profileId AND isPrivate = 0;";
      return _db.Query<Vault>(sql, new {profileId}).ToList();
    }

    public Profile Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}
