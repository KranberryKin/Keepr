using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

    public VaultKeep Create(VaultKeep data)
    {
      string sql = @"
      INSERT INTO vaultkeeps(creatorId, vaultId, keepId)
      VALUES(@CreatorId, @VaultId, @KeepId);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new {id});
    }

    public VaultKeep Edit(VaultKeep data)
    {
      string sql = @"
      UPDATE vaultkeeps 
      SET
      vaulID = @VaultId
      WHERE id = @Id LIMIT 1;
      ";
      var rowsAffected = _db.Execute(sql, data);
      if (rowsAffected == 0)
      {
        throw new System.Exception("Update Failed");
      }
      return data;
    }

    public List<VaultKeep> Get()
    {
      string sql = "SELECT * FROM vaultkeeps;";
      return _db.Query<VaultKeep>(sql).ToList();
    }

    public VaultKeep Get(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new {id});
    }
  }
}
