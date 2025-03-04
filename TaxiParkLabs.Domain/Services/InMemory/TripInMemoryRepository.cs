using TaxiParkLabs.Domain.Data;
using TaxiParkLabs.Domain.Model;

namespace TaxiParkLabs.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для Поездок, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class TripInMemoryRepository : ITripRepository
{
    private List<Trip> _trips;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public TripInMemoryRepository()
    {
        _trips = DataSeeder.Trips;
    }

    /// <inheritdoc/>
    public Task<Trip> Add(Trip entity)
    {
        _trips.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var trip = await Get(key);
        if (trip != null)
        {
            _trips.Remove(trip);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<Trip> Update(Trip entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <inheritdoc/>
    public Task<Trip?> Get(int key) =>
        Task.FromResult(_trips.FirstOrDefault(t => t.Id == key));

    /// <inheritdoc/>
    public Task<IList<Trip>> GetAll() =>
        Task.FromResult((IList<Trip>)_trips);

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int tripCount, double avgTravelTime, int maxTravelTime)>> GetDriverTripStatistics()
    {
        var statistics = _trips
            .GroupBy(t => t.CarId)
            .Select(g => (
                driver: new Driver { Id = g.Key },
                tripCount: g.Count(),
                avgTravelTime: g.Average(t => t.TravelTime ?? 0),
                maxTravelTime: g.Max(t => t.TravelTime ?? 0)))
            .ToList();

        return Task.FromResult((IList<(Driver, int, double, int)>)statistics);
    }
}
