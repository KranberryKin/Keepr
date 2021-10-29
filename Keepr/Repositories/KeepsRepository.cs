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

    public Keep Create(int id)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Keep Edit(int id, Keep data)
    {
      throw new System.NotImplementedException();
    }

    public List<Keep> Get()
    {
      string sql = "SELECT * FROM keeps;";
      return _db.Query<Keep>(sql).ToList();
    }

    public Keep Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}