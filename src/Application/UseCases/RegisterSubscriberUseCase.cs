using TelecomAccounting.Domain.Entities;
using TelecomAccounting.Domain.Interfaces;

namespace TelecomAccounting.Application.UseCases;

public class RegisterSubscriberUseCase
{
    private readonly ISubscriberRepository _repository;
    public RegisterSubscriberUseCase(ISubscriberRepository repository) => _repository = repository;

    public void Execute(string fullName, string phone, string ip, TariffPlan tariff)
    {
        if (_repository.GetByPhone(phone) != null)
            throw new Exception("Абонент з таким номером вже існує.");
        _repository.Add(new Subscriber { FullName = fullName, PhoneNumber = phone, IpAddress = ip, CurrentTariff = tariff });
    }
}
