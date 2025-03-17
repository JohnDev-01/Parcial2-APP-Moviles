using System;
using SQLite;

namespace examen2;

public class DatabaseService
{
  private SQLiteAsyncConnection _database;
  public DatabaseService()
  {
    string url = Path.Combine(FileSystem.AppDataDirectory, "ambulancias.db");
    _database = new SQLiteAsyncConnection(url);
    _database.CreateTableAsync<RegistroAmbulancia>().Wait();
  }
  public async Task<List<RegistroAmbulancia>> GetRegistrosAsync()
  {
    return await _database.Table<RegistroAmbulancia>().ToListAsync();
  }
  public async Task SaveRegistroAsync(RegistroAmbulancia registro)
  {
    await _database.InsertAsync(registro);
  }
}
