using System.Collections.Generic;
using Keepr.Interfaces;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ProfilesService : IService<Profile>
  {
    private readonly ProfilesRepository _pr;

    public ProfilesService(ProfilesRepository pr)
    {
      _pr = pr;
    }

    public Profile Create(Profile data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id, string userId)
    {
      throw new System.NotImplementedException();
    }

    public Profile Edit(Profile data, string userId)
    {
      throw new System.NotImplementedException();
    }

    public List<Profile> Get()
    {
      throw new System.NotImplementedException();
    }

    internal List<Keep> GetKeeps(string profileId)
    {
      return _pr.GetKeeps(profileId);
    }

    public Profile Get(string profileId)
    {
      return _pr.Get(profileId);
    }

    public Profile Get(int id)
    {
      throw new System.NotImplementedException();
    }

    internal List<Vault> GetVaults(string profileId)
    {
      return _pr.GetVaults(profileId);
    }
  }
}