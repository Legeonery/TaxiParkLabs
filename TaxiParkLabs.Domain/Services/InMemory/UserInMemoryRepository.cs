using TaxiParkLabs.Domain.Data;
using TaxiParkLabs.Domain.Model;

namespace TaxiParkLabs.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для Пользователей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class UserInMemoryRepository : IUserRepository
{
    private List<User> _users;
    private List<UsersTrip> _usersTrips;
    private List<Trip> _trips;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public UserInMemoryRepository()
    {
        _users = DataSeeder.Users;
        _usersTrips = DataSeeder.UsersTrips;
        _trips = DataSeeder.Trips;
    }

    /// <inheritdoc/>
    public Task<User> Add(User entity)
    {
        _users.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var user = await Get(key);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<User> Update(User entity)
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
    public Task<User?> Get(int key) =>
        Task.FromResult(_users.FirstOrDefault(u => u.Id == key));

    /// <inheritdoc/>
    public Task<IList<User>> GetAll() =>
        Task.FromResult((IList<User>)_users);

    /// <inheritdoc/>
    public Task<IList<User>> GetPassengersByTripPeriod(int startDate, int endDate)
    {
        var passengers = _usersTrips
            .Where(ut => _trips.Any(t => t.Id == ut.TripId && t.TripDate >= startDate && t.TripDate <= endDate))
            .Select(ut => _users.FirstOrDefault(u => u.Id == ut.UserId))
            .Where(u => u != null)
            .Select(u => u!)
            .OrderBy(u => u.LastName)
            .ToList();

        return Task.FromResult<IList<User>>(passengers);
    }



    /// <inheritdoc/>
    public Task<IList<(User user, int tripCount)>> GetTripCountByPassenger()
    {
        var tripCounts = _usersTrips
            .GroupBy(ut => ut.UserId)
            .Select(g => (user: _users.FirstOrDefault(u => u.Id == g.Key), tripCount: g.Count()))
            .Where(x => x.user != null)
            .ToList();

        return Task.FromResult((IList<(User, int)>)tripCounts);
    }

    /// <inheritdoc/>
    public Task<IList<User>> GetTopPassengersByTripPeriod(int startDate, int endDate)
    {
        var topPassengers = _usersTrips
            .Where(ut => _trips.Any(t => t.Id == ut.TripId && t.TripDate >= startDate && t.TripDate <= endDate))
            .GroupBy(ut => ut.UserId)
            .OrderByDescending(g => g.Count())
            .Select(g => _users.FirstOrDefault(u => u.Id == g.Key))
            .Where(u => u != null)
            .Select(u => u!)
            .ToList();

        return Task.FromResult<IList<User>>(topPassengers);
    }

}