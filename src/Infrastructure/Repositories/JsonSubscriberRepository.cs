using System.Text.Json;
using TelecomAccounting.Domain.Entities;
using TelecomAccounting.Domain.Interfaces;

namespace TelecomAccounting.Infrastructure.Repositories;

public class JsonSubscriberRepository : ISubscriberRepository
{
    private readonly string _filePath;
    private readonly List<Subscriber> _subscribers;

    public JsonSubscriberRepository(string filePath)
    {
        _filePath = filePath;
        _subscribers = File.Exists(_filePath)
            ? JsonSerializer.Deserialize<List<Subscriber>>(File.ReadAllText(_filePath)) ?? new()
            : new();
    }

    public void Add(Subscriber subscriber) { _subscribers.Add(subscriber); SaveChanges(); }
    public Subscriber? GetByPhone(string phoneNumber) => _subscribers.FirstOrDefault(s => s.PhoneNumber == phoneNumber);
    public IEnumerable<Subscriber> GetAll() => _subscribers;
    public void Update(Subscriber subscriber)
    {
        var index = _subscribers.FindIndex(s => s.Id == subscriber.Id);
        if (index != -1) { _subscribers[index] = subscriber; SaveChanges(); }
    }
    private void SaveChanges() => File.WriteAllText(_filePath, JsonSerializer.Serialize(_subscribers, new JsonSerializerOptions { WriteIndented = true }));
}
