using TaxiParkLabs.Domain.Model;
using TaxiParkLabs.Domain.Services;

namespace TaxiParkLabs.Domain.Services;
/// <summary>
/// Репозиторий для работы с Пользователями.
/// </summary>
public interface IUserRepository : IRepository<User, int>
{
    /// <summary>
    /// Получить всех пассажиров, совершивших поездки за указанный период, упорядоченных по ФИО.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список пользователей.</returns>
    Task<IList<User>> GetPassengersByTripPeriod(int startDate, int endDate);

    /// <summary>
    /// Получить количество поездок каждого пассажира.
    /// </summary>
    /// <returns>Список пользователей и количества их поездок.</returns>
    Task<IList<(User user, int tripCount)>> GetTripCountByPassenger();

    /// <summary>
    /// Получить пассажиров, совершивших максимальное количество поездок за указанный период.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список пассажиров с максимальным числом поездок.</returns>
    Task<IList<User>> GetTopPassengersByTripPeriod(int startDate, int endDate);
}
