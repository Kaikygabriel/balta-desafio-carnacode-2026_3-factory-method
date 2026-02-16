using System;
using src.Enum;
using src.Interfaces;
using src.Models;

namespace src.Notifications;

public class PushNotification  : INotification
{
    public string DeviceToken { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public int Badge { get; set; }
    

    public void Send(NotificationRequest request)
    {
        var (title, message, badge) = request.Kind switch
        {
            NotificationKind.OrderConfirmation =>
                ("Pedido Confirmado", $"Pedido {request.OrderNumber} confirmado!", 1),

            NotificationKind.ShippingUpdate =>
                ("Pedido Enviado", $"Rastreamento: {request.TrackingCode}", 1),

            NotificationKind.PaymentReminder =>
                ("Lembrete", $"Pagamento pendente: R$ {request.Amount:N2}", 1),

            _ => throw new ArgumentOutOfRangeException()
        };
        
        Console.WriteLine($"🔔 Enviando Push para dispositivo {DeviceToken}");
        Console.WriteLine($"   Título: {Title}");
        Console.WriteLine($"   Mensagem: {Message}");
    }
}
