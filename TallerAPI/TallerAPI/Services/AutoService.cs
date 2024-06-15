namespace TallerAPI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TallerAPI.Models;


public class AutoService
{
    private readonly IMongoCollection<Automovil> _autoCollections;

    public AutoService(IOptions<AutoDbSettings> autoDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            autoDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            autoDatabaseSettings.Value.DatabaseName);

        _autoCollections = mongoDatabase.GetCollection<Automovil>(
            autoDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Automovil>> GetAsync() =>
        await _autoCollections.Find(_ => true).ToListAsync();

    public async Task<Automovil?> GetAsync(string id) =>
        await _autoCollections.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Automovil newAutomovil) =>
        await _autoCollections.InsertOneAsync(newAutomovil);

    public async Task UpdateAsync(string id, Automovil updatedAutomovil) =>
        await _autoCollections.ReplaceOneAsync(x => x.id == id, updatedAutomovil);

    public async Task RemoveAsync(string id) =>
        await _autoCollections.DeleteOneAsync(x => x.id == id);
}

