namespace TelecomAccounting.Domain.Entities;

public class Subscriber
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
    // Валідація номера телефону
    public string PhoneNumber { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public TariffPlan CurrentTariff { get; set; } = new();

    public void ChangeTariff(TariffPlan newTariff)
    {
        if (!IsActive)
            throw new InvalidOperationException("Неможливо змінити тариф для заблокованого абонента.");
        CurrentTariff = newTariff;
    }
}
