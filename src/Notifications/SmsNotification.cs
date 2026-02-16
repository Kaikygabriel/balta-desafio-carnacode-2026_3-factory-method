using System;
using src.Enum;
using src.Interfaces;
using src.Models;

namespace src.Notifications;

public class SmsNotification : INotification
{
    public SmsNotification()
    {
        
    }
    public SmsNotification(string phoneNumber, string message)
    {
        PhoneNumber = phoneNumber;
        Message = message;
    }

    public string PhoneNumber { get; set; }
    public string Message { get; set; }

    public void Send(NotificationRequest request)
    {
        var message = request.Kind switch
        {
            NotificationKind.OrderConfirmation =>
                $"Pedido {request.OrderNumber} confirmado!",

            NotificationKind.ShippingUpdate =>
                $"Pedido enviado! Rastreamento: {request.TrackingCode}",

            NotificationKind.PaymentReminder =>
                $"Pagamento pendente: R$ {request.Amount:N2}",

            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine($"📱 Enviando SMS para {PhoneNumber}");
        Console.WriteLine($"   Mensagem: {Message}");
    }
}