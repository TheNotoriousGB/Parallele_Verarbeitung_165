using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    private static readonly IMongoCollection<DeathRecord> _deathRecordsCollection;

    static Program()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("LB_165_GabrielBischof");
        _deathRecordsCollection = database.GetCollection<DeathRecord>("weekly_deaths");
    }

    public static async Task Main(string[] args)
    {
        var deathRecords = await _deathRecordsCollection.Find(_ => true).ToListAsync();

        Parallel.ForEach(deathRecords, record =>
        {
            CalculateDifference(record);
        });

        foreach (var record in deathRecords)
        {
            Console.WriteLine($"Year: {record.Year}, Week: {record.Week}, Difference: {record.Diff}");
        }
    }

    private static void CalculateDifference(DeathRecord record)
    {
        record.Diff = (record.NoDeaths_EP - record.Expected).ToString();
    }
}
