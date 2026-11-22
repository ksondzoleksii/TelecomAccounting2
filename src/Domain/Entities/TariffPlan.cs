namespace TelecomAccounting.Domain.Entities;

public class TariffPlan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public decimal MonthlyFee { get; set; }
    public int SpeedMbps { get; set; }
}
