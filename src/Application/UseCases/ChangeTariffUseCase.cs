using TelecomAccounting.Domain.Entities;
using TelecomAccounting.Domain.Interfaces;

namespace TelecomAccounting.Application.UseCases;

public class ChangeTariffUseCase
{
    private readonly ISubscriberRepository _repository;
    public ChangeTariffUseCase(ISubscriberRepository repository) => _repository = repository;

    public void Execute(string phone, TariffPlan newTariff)
    {
        var subscriber = _repository.GetByPhone(phone) ?? throw new Exception("Абонента не знайдено.");
        subscriber.ChangeTariff(newTariff);
        _repository.Update(subscriber);
    }
}
