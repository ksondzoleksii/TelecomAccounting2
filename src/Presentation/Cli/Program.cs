using TelecomAccounting.Application.UseCases;
using TelecomAccounting.Domain.Entities;
using TelecomAccounting.Domain.Interfaces;
using TelecomAccounting.Infrastructure.Repositories;

ISubscriberRepository repository = new JsonSubscriberRepository("telecom_db.json");
var registerUseCase = new RegisterSubscriberUseCase(repository);
var changeTariffUseCase = new ChangeTariffUseCase(repository);

var basicTariff = new TariffPlan { Name = "Оптичний 100", MonthlyFee = 250m, SpeedMbps = 100 };
var gigabitTariff = new TariffPlan { Name = "Гігабіт Pro", MonthlyFee = 450m, SpeedMbps = 1000 };

registerUseCase.Execute("Іваненко Іван Іванович", "+380671234567", "192.168.10.15", basicTariff);
Console.WriteLine("Абонента зареєстровано!");

changeTariffUseCase.Execute("+380671234567", gigabitTariff);
Console.WriteLine("Тариф успішно змінено на Гігабіт Pro!");

foreach (var sub in repository.GetAll())
{
    Console.WriteLine($"Абонент: {sub.FullName} | Тел: {sub.PhoneNumber} | IP: {sub.IpAddress} | Тариф: {sub.CurrentTariff.Name} ({sub.CurrentTariff.SpeedMbps} Мбіт/с)");
}
