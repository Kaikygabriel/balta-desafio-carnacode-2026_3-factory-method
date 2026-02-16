using System;
using src.Enum;
using src.Interfaces;
using src.Models;

namespace src.Notifications;

public class EmailNotification : INotification
{
    public EmailNotification(string recipient, string subject, string body, bool isHtml)
    {
        Recipient = recipient;
        Subject = subject;
        Body = body;
        IsHtml = isHtml;
    }

    public EmailNotification()
    {
        
    }
    public string Recipient { get;private set; }
    public string Subject { get;private  set; }
    public string Body { get;private  set; }
    public bool IsHtml { get; private  set; }

    public void Send(NotificationRequest request)
    {
        
        var (subject, body, isHtml) = request.Kind switch
        {
            NotificationKind.OrderConfirmation =>
                ("Confirmação de Pedido", $"Seu pedido {request.OrderNumber} foi confirmado!", true),

            NotificationKind.ShippingUpdate =>
                ("Pedido Enviado", $"Seu pedido foi enviado! Código de rastreamento: {request.TrackingCode}", true),

            NotificationKind.PaymentReminder =>
                ("Lembrete de Pagamento", $"Você tem um pagamento pendente de R$ {request.Amount:N2}", true),

            _ => throw new ArgumentOutOfRangeException()
        };
        
        Console.WriteLine($"📧 Enviando Email para {Recipient}");
        Console.WriteLine($"   Assunto: {Subject}");
        Console.WriteLine($"   Mensagem: {Body}");
    }
}