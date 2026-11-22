# TelecomAccounting2 — Облік даних про телекомунікації

Консольний застосунок на C# (.NET), побудований за принципами **Clean Architecture**.

## Архітектура застосунку

```mermaid
graph TD
    Presentation[Presentation Layer: CLI Program.cs] --> Application[Application Layer: Use Cases]
    Presentation --> Infrastructure[Infrastructure Layer: JsonSubscriberRepository]
    Application --> Domain[Domain Layer: Entities & ISubscriberRepository]
    Infrastructure --> Domain
dotnet build
dotnet run
