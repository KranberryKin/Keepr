using System.Collections.Generic;

namespace Keepr.Interfaces
{
  public interface IRepository<T>
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
    T Create(T data);
    /// <summary>
    /// Takes updated 
    /// </summary>
    /// <returns>Edited Object</returns>
    T Edit(T data);
    /// <summary>
    /// Finds item by it's Id and removes it form the database.
    /// </summary>
    void Delete(int id);
  }
}