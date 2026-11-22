using TelecomAccounting.Domain.Entities;

namespace TelecomAccounting.Domain.Interfaces;

public interface ISubscriberRepository
{
    void Add(Subscriber subscriber);
    Subscriber? GetByPhone(string phoneNumber);
    IEnumerable<Subscriber> GetAll();
    void Update(Subscriber subscriber);
}
