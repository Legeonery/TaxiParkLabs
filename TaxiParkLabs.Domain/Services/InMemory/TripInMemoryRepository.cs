using TaxiParkLabs.Domain.Data;
using TaxiParkLabs.Domain.Model;

namespace TaxiParkLabs.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для Поездок, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class TripInMemoryRepository : ITripRepository
{
    private readonly List<Trip> _trips;
    private readonly List<Driver> _drivers;
    private readonly List<DriverCar> _driverCars;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public TripInMemoryRepository()
    {
        _trips = DataSeeder.Trips;
        _drivers = DataSeeder.Drivers;
        _driverCars = DataSeeder.DriverCars;
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
    public Task<Trip> Update(Trip entity)
    {
        var existingTrip = _trips.FirstOrDefault(d => d.Id == entity.Id);
        if (existingTrip != null)
        {           
            existingTrip.Id = entity.Id;
            existingTrip.DeparturePoint = entity.DeparturePoint;
            existingTrip.DestinationPoint = entity.DestinationPoint;
            existingTrip.TripDate = entity.TripDate;
            existingTrip.TravelTime = entity.TravelTime;
            existingTrip.Cost = entity.Cost;
            existingTrip.CarId = entity.CarId;
        }
        return Task.FromResult(entity);
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
            .Select(g =>
            {
                var driverCar = _driverCars.FirstOrDefault(dc => dc.CarId == g.Key);
                var driver = driverCar != null ? _drivers.FirstOrDefault(d => d.Id == driverCar.DriverId) : null;
                return driver != null
                    ? (driver, g.Count(), g.Average(t => t.TravelTime ?? 0), g.Max(t => t.TravelTime ?? 0))
                    : default;
            })
            .Where(stat => stat.driver != null)
            .ToList();

        return Task.FromResult((IList<(Driver, int, double, int)>)statistics);
    }
}
