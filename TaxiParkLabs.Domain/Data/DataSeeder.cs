using TaxiParkLabs.Domain.Model;

namespace TaxiParkLabs.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция автомобилей для начального наполнения
    /// </summary>
    public static readonly List<Car> Cars =
    [
        new() { Id = 1, StateNumber = "Р001МТ", Model = "Camry", YearOfProduction = 2020 },
        new() { Id = 2, StateNumber = "Р002МТ", Model = "Sonata", YearOfProduction = 2019 },
        new() { Id = 3, StateNumber = "Р003МТ", Model = "Focus", YearOfProduction = 2018 },
        new() { Id = 4, StateNumber = "Р004МТ", Model = "Optima", YearOfProduction = 2021 },
        new() { Id = 5, StateNumber = "Р005МТ", Model = "Passat", YearOfProduction = 2017 }
    ];

    /// <summary>
    /// Коллекция водителей для начального наполнения
    /// </summary>
    public static readonly List<Driver> Drivers =
    [
        new() { Id = 1, FirstName = "Иван", LastName = "Петров" },
        new() { Id = 2, FirstName = "Андрей", LastName = "Сидоров" },
        new() { Id = 3, FirstName = "Сергей", LastName = "Иванов" },
        new() { Id = 4, FirstName = "Дмитрий", LastName = "Кузнецов" },
        new() { Id = 5, FirstName = "Алексей", LastName = "Федоров" }
    ];

    /// <summary>
    /// Коллекция связей водителей и автомобилей
    /// </summary>
    public static readonly List<DriverCar> DriverCars =
    [
        new() { Id = 1, DriverId = 1, CarId = 1 },
        new() { Id = 2, DriverId = 2, CarId = 2 },
        new() { Id = 3, DriverId = 3, CarId = 3 },
        new() { Id = 4, DriverId = 4, CarId = 4 },
        new() { Id = 5, DriverId = 5, CarId = 5 }
    ];

    /// <summary>
    /// Коллекция пользователей (пассажиров)
    /// </summary>
    public static readonly List<User> Users =
    [
        new() { Id = 1, FirstName = "Мария", LastName = "Смирнова" },
        new() { Id = 2, FirstName = "Ольга", LastName = "Козлова" },
        new() { Id = 3, FirstName = "Павел", LastName = "Морозов" },
        new() { Id = 4, FirstName = "Анна", LastName = "Васильева" },
        new() { Id = 5, FirstName = "Роман", LastName = "Зайцев" }
    ];

    /// <summary>
    /// Коллекция поездок
    /// </summary>
    public static readonly List<Trip> Trips =
    [
        new() { Id = 1, CarId = 1, TripDate = 20240215, TravelTime = 25 },
        new() { Id = 2, CarId = 2, TripDate = 20240216, TravelTime = 30 },
        new() { Id = 3, CarId = 3, TripDate = 20240217, TravelTime = 15 },
        new() { Id = 4, CarId = 4, TripDate = 20240218, TravelTime = 20 },
        new() { Id = 5, CarId = 5, TripDate = 20240219, TravelTime = 35 }
    ];

    /// <summary>
    /// Коллекция связей пользователей и поездок
    /// </summary>
    public static readonly List<UsersTrip> UsersTrips =
    [
        new() { Id = 1, UserId = 1, TripId = 1 },
        new() { Id = 2, UserId = 2, TripId = 2 },
        new() { Id = 3, UserId = 3, TripId = 3 },
        new() { Id = 4, UserId = 4, TripId = 4 },
        new() { Id = 5, UserId = 5, TripId = 5 }
    ];
}
