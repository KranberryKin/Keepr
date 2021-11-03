using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

    public Vault Create(Vault data)
    {
      string sql = @"
      INSERT INTO vaults(creatorId, name, description, isPrivate)
      VALUES(@CreatorId, @Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      var foundVault = Get(data.Id);
      return foundVault;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      var rowsAffected = _db.Execute(sql, new {id});
      if (rowsAffected == 0)
      {
        throw new System.Exception("Updating Keep Failed!");
      }
    }

    public Vault Edit(Vault data)
    {
      string sql = @"
      UPDATE vaults
      SET
      name = @Name,
      description = @Description,
      isPrivate = @IsPrivate
      WHERE id = @Id LIMIT 1;
      ";
      var rowsAffected = _db.Execute(sql, data);
      if (rowsAffected == 0)
      {
        throw new System.Exception("Update Failed");
      }
      return data;
    }

    internal List<VaultKeepView> GetVaultsKeeps(int vaultId)
    {
      string sql = @"
      SELECT 
      k.*,
      vk.id AS VaultKeepId,
      a.*
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN accounts a ON a.id = k.creatorId
      WHERE vk.vaultId = @vaultId;
      ";
      return _db.Query<VaultKeepView, Profile, VaultKeepView>(sql, (k, a) => {
        k.Creator = a;
        return k;
      }, new {vaultId}, splitOn : "id").ToList();
    }

    public List<Vault> Get()
    {
      string sql = @"
      SELECT 
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId;";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) => 
      {
        v.Creator = a;
        return v;
      }).ToList();
    }

    public Vault Get(int id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id;
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) => 
      {
        v.Creator = a;
        return v;
      }, new {id}).FirstOrDefault();
    }
  }
}
