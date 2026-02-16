using System;
using src.Enum;
using src.Interfaces;
using src.Models;

namespace src.Notifications;

 public class WhatsAppNotification  : INotification
 {
     public WhatsAppNotification()
     {
         
     }
     public WhatsAppNotification(string phoneNumber, string message, bool useTemplate)
     {
         PhoneNumber = phoneNumber;
         Message = message;
         UseTemplate = useTemplate;
     }

     public string PhoneNumber { get; set; }
     public string Message { get; set; }
     public bool UseTemplate { get; set; }

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

         Console.WriteLine($"💬 Enviando WhatsApp para {PhoneNumber}");
         Console.WriteLine($"   Mensagem: {Message}");
         Console.WriteLine($"   Template: {UseTemplate}");
     }
 }