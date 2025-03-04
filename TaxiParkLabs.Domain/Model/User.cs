using System.ComponentModel.DataAnnotations;

namespace TaxiParkLabs.Domain.Model;
///<summary>
///Класс пользователь
///</summary>
public class User
{
    /// <summary>
    /// Индификатор пользователя 
    /// </summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Имя пользователя 
    ///</summary>
    public string? LastName { get; set; }

    ///<summary>
    ///Фамилия пользователя 
    ///</summary>
    public string? FirstName { get; set; }

    ///<summary>
    ///Отчество пользователя 
    ///</summary>
    public string? Patronymic { get; set; }
    ///<summary>
    ///Телефон пользователя
    ///</summary>
    public string? PhoneNumber { get; set; }
}

