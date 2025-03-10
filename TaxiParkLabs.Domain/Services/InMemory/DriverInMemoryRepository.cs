using TaxiParkLabs.Domain.Model;
using TaxiParkLabs.Domain.Services;
using TaxiParkLabs.Domain.Data;

namespace TaxiParkLabs.Domain.Services.InMemory;
/// <summary>
/// Реализация репозитория для работы с водителями в памяти.
/// </summary>
public class DriverInMemoryRepository : IDriverRepository
{
    private readonly List<Driver> _drivers;
    private readonly List<Car> _cars;
    private readonly List<DriverCar> _driverCars;
    private readonly List<Trip> _trips;

    /// <inheritdoc/>
    public DriverInMemoryRepository()
    {
        _drivers = DataSeeder.Drivers;
        _cars = DataSeeder.Cars;
        _driverCars = DataSeeder.DriverCars;
        _trips = DataSeeder.Trips;
    }

    /// <inheritdoc/>
    public Task<IList<Driver>> GetAll()
    {
        return Task.FromResult<IList<Driver>>(_drivers);
    
    }

    /// <inheritdoc/>
    public Task<Driver?> Get(int key)
    {
        var driver = _drivers.FirstOrDefault(d => d.Id == key);
        return Task.FromResult(driver);
    }

    /// <inheritdoc/>
    public Task<Driver> Add(Driver entity)
    {
        if (!_drivers.Any(d => d.Id == entity.Id))
        {
            _drivers.Add(entity);
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Driver> Update(Driver entity)
    {
        var existingDriver = _drivers.FirstOrDefault(d => d.Id == entity.Id);
        if (existingDriver != null)
        {
            existingDriver.FirstName = entity.FirstName;
            existingDriver.LastName = entity.LastName;
            existingDriver.Patronymic = entity.Patronymic;
            existingDriver.PhoneNumber = entity.PhoneNumber;
            existingDriver.PassportSeries = entity.PassportSeries;
            existingDriver.PassportNumber = entity.PassportNumber;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<bool> Delete(int key)
    {
        var driver = _drivers.FirstOrDefault(d => d.Id == key);
        if (driver != null)
        {
            _drivers.Remove(driver);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <inheritdoc/>
    public Task<(Driver driver, Car car)?> GetDriverWithCar(int Id)
    {
        var driverCar = _driverCars.FirstOrDefault(dc => dc.DriverId == Id);
        if (driverCar != null)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == driverCar.DriverId);
            var car = _cars.FirstOrDefault(c => c.Id == driverCar.CarId);
            if (driver != null && car != null)
            {
                return Task.FromResult<(Driver, Car)?>((driver, car));
            }
        }
        return Task.FromResult<(Driver, Car)?>(null);
    }

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int tripCount)>> GetTop5DriversByTripCount()
    {
        var topDrivers = _trips
            .GroupBy(t => t.CarId)
            .Select(g => new
            {
                Driver = _drivers.FirstOrDefault(d => _driverCars.Any(dc => dc.DriverId == d.Id && dc.CarId == g.Key)),
                TripCount = g.Count()
            })
            .Where(x => x.Driver != null)
            .OrderByDescending(x => x.TripCount)
            .Take(5)
            .Select(x => (x.Driver!, x.TripCount))
            .ToList();

        return Task.FromResult<IList<(Driver, int)>>(topDrivers);
    }

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int tripCount, double avgTravelTime, int maxTravelTime)>> GetDriverTripStatistics()
    {
        var driverStats = _trips
            .GroupBy(t => t.CarId)
            .Select(g => new
            {
                Driver = _drivers.FirstOrDefault(d => _driverCars.Any(dc => dc.DriverId == d.Id && dc.CarId == g.Key)),
                TripCount = g.Count(),
                AvgTravelTime = g.Average(t => t.TravelTime ?? 0),
                MaxTravelTime = g.Max(t => t.TravelTime ?? 0)
            })
            .Where(x => x.Driver != null)
            .Select(x => (x.Driver!, x.TripCount, x.AvgTravelTime, x.MaxTravelTime))
            .ToList();

        return Task.FromResult<IList<(Driver, int, double, int)>>(driverStats);
    }
}
