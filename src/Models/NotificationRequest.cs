using src.Enum;

namespace src.Models;

public class NotificationRequest
{
    public  NotificationKind Kind { get; set; }
    public string Recipient { get; init; } = default!;

    public string? OrderNumber { get; init; }
    public string? TrackingCode { get; init; }
    public decimal? Amount { get; init; }
    
}