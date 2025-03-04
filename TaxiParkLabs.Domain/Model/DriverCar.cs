using System.ComponentModel.DataAnnotations;

namespace TaxiParkLabs.Domain.Model;
///<summary>
///Класс связывающий водителей и ТС
///</summary>
public class DriverCar
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор ТС
    /// </summary>
    public required int CarId { get; set; }

    /// <summary>
    /// Навигейшен ТС
    /// </summary>
    ///public virtual Car? Car { get; set; }

    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public required int DriverId { get; set; }

    /// <summary>
    /// Навигейшен водителя
    /// </summary>
    ///public virtual Driver? Driver { get; set; }
}

