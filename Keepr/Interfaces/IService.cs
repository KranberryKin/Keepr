using System.Collections.Generic;

namespace Keepr.Interfaces
{
  public interface IService<T>
  {
    /// <summary>
    /// Gets all items of a table, returns a list.
    /// </summary>
    List<T> Get();
    /// <summary>
    /// Returns a single items, find it by it's Id.
    /// </summary>
    T Get(int id);
    /// <summary>
    /// Adds the new item to the database and returns it.
    /// </summary>
    /// <returns>Created Object</returns>
    T Create(int id);
    /// <summary>
    /// Takes updated 
    /// </summary>
    /// <returns>Edited Object</returns>
    T Edit(int id, T data);
    /// <summary>
    /// Finds item by it's Id and removes it form the database.
    /// </summary>
    void Delete(int id);
  }
}