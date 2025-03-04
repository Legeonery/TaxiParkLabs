using System.ComponentModel.DataAnnotations;

namespace TaxiParkLabs.Domain.Model;
///<summary>
///Класс поездки
///</summary>
public class Trip
{
    ///<summary>
    ///Индификатор поездки
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Пункт отправления 
    ///</summary>
    public string? DeparturePoint { get; set; }
    ///<summary>
    ///Пункт назначения 
    ///</summary>
    public string? DestinationPoint { get; set; }
    ///<summary>
    ///Дата поездки
    ///</summary>
    public int? TripDate { get; set; }
    ///<summary>
    ///Время в пути
    ///</summary>
    public int? TravelTime { get; set; }
    ///<summary>
    ///Стоимость
    ///</summary>
    public int? Cost { get; set; }
    /// <summary>
    /// Назначеное ТС
    /// </summary>
    public required int CarId { get; set; }
    /// <summary>
    /// Навигейшен ТС
    /// </summary>
    ///public virtual Car? Car { get; set; }
}

