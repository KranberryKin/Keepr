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

    public Keep Create(Keep keepdata)
    {
      return _kr.Create(keepdata);
    }


    public void Delete(int id, string userId)
    {
      var foundKeep = Get(id);
      if (foundKeep.CreatorId != userId)
      {
        throw new System.Exception("Can't Remove this Keep!");
      }
      _kr.Delete(id);
    }


    public Keep Edit(Keep data, string userId)
    {
      Keep foundKeep = Get(data.Id);
      if (foundKeep.CreatorId != userId)
      {
        throw new System.Exception("You can Edit This!");
      }
      foundKeep.Name = data.Name ?? foundKeep.Name;
      foundKeep.Description = data.Description ?? foundKeep.Description;
      foundKeep.Img = data.Img ?? foundKeep.Img;
      foundKeep.Views = data.Views;
      foundKeep.Keeps = data.Keeps;
      foundKeep.Views = data.Views;
      return _kr.Edit(foundKeep);
    }

    public List<Keep> Get()
    {
      return _kr.Get();
    }

    public Keep Get(int keepId)
    {
      var foundKeep = _kr.Get(keepId);
       if (foundKeep == null)
       {
         throw new System.Exception("Can't find keep");
       }
      return foundKeep;
    }
  }
}