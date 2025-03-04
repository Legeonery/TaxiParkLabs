using System.ComponentModel.DataAnnotations;

namespace TaxiParkLabs.Domain.Model;
///<summary>
///Класс ТС
///</summary>
public class Car
{
    ///<summary>
    ///Индификатор ТС
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Гос. номер ТС
    ///</summary>
    public required string? StateNumber { get; set; }
    ///<summary>
    ///Модель ТС
    ///</summary>
    public string? Model { get; set; }
    ///<summary>
    ///Основной цвет ТС
    ///</summary>
    public string? Color { get; set; }
    ///<summary>
    ///Год выпуска ТС
    ///</summary>
    public int? YearOfProduction { get; set; }
}

