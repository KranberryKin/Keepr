using System.Collections.Generic;
using Keepr.Interfaces;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService : IService<Keep>
  {
    private readonly KeepsRepository _kr;

    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
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
      return _kr.Get();
    }

    public Keep Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}