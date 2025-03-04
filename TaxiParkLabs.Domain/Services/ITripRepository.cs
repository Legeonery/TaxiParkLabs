using TaxiParkLabs.Domain.Model;
using TaxiParkLabs.Domain.Services;

namespace TaxiParkLabs.Domain.Services;
/// <summary>
/// Репозиторий для работы с Поездками.
/// </summary>
public interface ITripRepository : IRepository<Trip, int>
{
    /// <summary>
    /// Получить количество поездок, среднее и максимальное время поездки для каждого водителя.
    /// </summary>
    /// <returns>Список данных о поездках водителей.</returns>
    Task<IList<(Driver driver, int tripCount, double avgTravelTime, int maxTravelTime)>> GetDriverTripStatistics();
}
