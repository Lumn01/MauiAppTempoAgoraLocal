using MauiAppTempoAgoraLocal;
using SQLite;
public class DatabaseService
{

    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);

        _database.CreateTableAsync<TempoData>().Wait();
    }

    public Task<int> AddWeatherDataAsync(TempoData data)
    {
        return _database.InsertAsync(data);
    }

    public Task<List<TempoData>> GetWeatherDataAsync()
    {
        return _database.Table<TempoData>().ToListAsync();
    }
}
