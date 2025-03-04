using TaxiParkLabs.Domain.Model;

namespace TaxiParkLabs.Domain.Services;
/// <summary>
/// Репозиторий для работы с водителями.
/// </summary>
public interface IDriverRepository : IRepository<Driver, int>
{
    /// <summary>
    /// Получить все сведения о конкретном водителе и его автомобиле.
    /// </summary>
    /// <param name="Id">Идентификатор водителя.</param>
    /// <returns>Данные о водителе и его автомобиле.</returns>
    Task<(Driver driver, Car car)?> GetDriverWithCar(int Id);

    /// <summary>
    /// Получить топ 5 водителей по количеству поездок.
    /// </summary>
    /// <returns>Список из 5 водителей и количества их поездок.</returns>
    Task<IList<(Driver driver, int tripCount)>> GetTop5DriversByTripCount();
    /// <summary>
    /// Получить информацию о количестве поездок, среднем и максимальном времени поездки для каждого водителя.
    /// </summary>
    /// <returns>Список водителей с данными по их поездкам.</returns>
    Task<IList<(Driver driver, int tripCount, double avgTravelTime, int maxTravelTime)>> GetDriverTripStatistics();
}