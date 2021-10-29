using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Interfaces;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository : IRepository<Keep>
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Keep Create(Keep keepdata)
    {
      string sql = @"
      INSERT INTO keeps(creatorId, name, description, img)
      VALUES(@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, keepdata);
      keepdata.Id = id;
      return keepdata;
    }


    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
      var rowsAffected = _db.Execute(sql, new {id});
      if (rowsAffected == 0)
      {
        throw new System.Exception("Updating Keep Failed!");
      }
    }

    public Keep Edit(Keep data)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img
      WHERE id = @Id LIMIT 1;
      ";
      var rowsAffected = _db.Execute(sql, data);
      if (rowsAffected == 0)
      {
        throw new System.Exception("Update Failed");
      }
      return data;
    }

    public List<Keep> Get()
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) => 
      {
        k.Creator = a;
        return k;
      }).ToList();
    }

    public Keep Get(int keepId)
    {
      string sql = @"
      SELECT
       k.*,
       a.*
       FROM keeps k
       JOIN accounts a ON a.id = k.creatorId
       WHERE k.id = @keepId;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) => 
      {
        k.Creator = a;
        return k;
      }, new {keepId}).FirstOrDefault();
    }
  }
}