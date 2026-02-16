// // DESAFIO: Sistema de Notificações Multi-Canal
// // PROBLEMA: Uma aplicação de e-commerce precisa enviar notificações por diferentes canais
// // (Email, SMS, Push, WhatsApp) dependendo da preferência do cliente e tipo de notificação
// // O código atual viola o Open/Closed Principle ao usar condicionais para criar notificações
//
// using System;
//
// namespace DesignPatternChallenge
// {
//     // Contexto: Sistema de notificações que envia mensagens para clientes
//     // Cada tipo de notificação tem requisitos e formatação diferentes
//     
//     public class NotificationManager
//     {
//         public void SendOrderConfirmation(string recipient, string orderNumber, string notificationType)
//         {
//             // Problema: Lógica de criação de notificações acoplada no método
//             // Adicionar novo tipo de notificação requer modificar este código
//             
//             if (notificationType == "email")
//             {
//                 var email = new EmailNotification();
//                 email.Recipient = recipient;
//                 email.Subject = "Confirmação de Pedido";
//                 email.Body = $"Seu pedido {orderNumber} foi confirmado!";
//                 email.IsHtml = true;
//                 email.Send();
//             }
//             else if (notificationType == "sms")
//             {
//                 var sms = new SmsNotification();
//                 sms.PhoneNumber = recipient;
//                 sms.Message = $"Pedido {orderNumber} confirmado!";
//                 sms.Send();
//             }
//             else if (notificationType == "push")
//             {
//                 var push = new PushNotification();
//                 push.DeviceToken = recipient;
//                 push.Title = "Pedido Confirmado";
//                 push.Message = $"Pedido {orderNumber} confirmado!";
//                 push.Badge = 1;
//                 push.Send();
//             }
//             else if (notificationType == "whatsapp")
//             {
//                 var whatsapp = new WhatsAppNotification();
//                 whatsapp.PhoneNumber = recipient;
//                 whatsapp.Message = $"✅ Seu pedido {orderNumber} foi confirmado!";
//                 whatsapp.UseTemplate = true;
//                 whatsapp.Send();
//             }
//             else
//             {
//                 throw new ArgumentException($"Tipo de notificação '{notificationType}' não suportado");
//             }
//         }
//
//         public void SendShippingUpdate(string recipient, string trackingCode, string notificationType)
//         {
//             // Problema: Código duplicado - mesma estrutura condicional repetida
//             if (notificationType == "email")
//             {
//                 var email = new EmailNotification();
//                 email.Recipient = recipient;
//                 email.Subject = "Pedido Enviado";
//                 email.Body = $"Seu pedido foi enviado! Código de rastreamento: {trackingCode}";
//                 email.IsHtml = true;
//                 email.Send();
//             }
//             else if (notificationType == "sms")
//             {
//                 var sms = new SmsNotification();
//                 sms.PhoneNumber = recipient;
//                 sms.Message = $"Pedido enviado! Rastreamento: {trackingCode}";
//                 sms.Send();
//             }
//             else if (notificationType == "push")
//             {
//                 var push = new PushNotification();
//                 push.DeviceToken = recipient;
//                 push.Title = "Pedido Enviado";
//                 push.Message = $"Rastreamento: {trackingCode}";
//                 push.Badge = 1;
//                 push.Send();
//             }
//             else if (notificationType == "whatsapp")
//             {
//                 var whatsapp = new WhatsAppNotification();
//                 whatsapp.PhoneNumber = recipient;
//                 whatsapp.Message = $"📦 Pedido enviado! Rastreamento: {trackingCode}";
//                 whatsapp.UseTemplate = true;
//                 whatsapp.Send();
//             }
//         }
//         public void SendPaymentReminder(string recipient, decimal amount, string notificationType)
//         {
//             // Problema: Cada novo método repete a mesma lógica condicional
//             if (notificationType == "email")
//             {
//                 var email = new EmailNotification();
//                 email.Recipient = recipient;
//                 email.Subject = "Lembrete de Pagamento";
//                 email.Body = $"Você tem um pagamento pendente de R$ {amount:N2}";
//                 email.IsHtml = true;
//                 email.Send();
//             }
//             else if (notificationType == "sms")
//             {
//                 var sms = new SmsNotification();
//                 sms.PhoneNumber = recipient;
//                 sms.Message = $"Pagamento pendente: R$ {amount:N2}";
//                 sms.Send();
//             }
//             // ... mesmo padrão se repete
//         }
//     }
//
//     // Classes concretas de notificação
//     public class EmailNotification
//     {
//         public string Recipient { get; set; }
//         public string Subject { get; set; }
//         public string Body { get; set; }
//         public bool IsHtml { get; set; }
//
//         public void Send()
//         {
//             Console.WriteLine($"📧 Enviando Email para {Recipient}");
//             Console.WriteLine($"   Assunto: {Subject}");
//             Console.WriteLine($"   Mensagem: {Body}");
//         }
//     }
//
//     public class SmsNotification
//     {
//         public string PhoneNumber { get; set; }
//         public string Message { get; set; }
//
//         public void Send()
//         {
//             Console.WriteLine($"📱 Enviando SMS para {PhoneNumber}");
//             Console.WriteLine($"   Mensagem: {Message}");
//         }
//     }
//
//     public class PushNotification
//     {
//         public string DeviceToken { get; set; }
//         public string Title { get; set; }
//         public string Message { get; set; }
//         public int Badge { get; set; }
//
//         public void Send()
//         {
//             Console.WriteLine($"🔔 Enviando Push para dispositivo {DeviceToken}");
//             Console.WriteLine($"   Título: {Title}");
//             Console.WriteLine($"   Mensagem: {Message}");
//         }
//     }
//
//     public class WhatsAppNotification
//     {
//         public string PhoneNumber { get; set; }
//         public string Message { get; set; }
//         public bool UseTemplate { get; set; }
//
//         public void Send()
//         {
//             Console.WriteLine($"💬 Enviando WhatsApp para {PhoneNumber}");
//             Console.WriteLine($"   Mensagem: {Message}");
//             Console.WriteLine($"   Template: {UseTemplate}");
//         }
//     }
//
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("=== Sistema de Notificações ===\n");
//
//             var manager = new NotificationManager();
//
//             // Cliente 1 prefere Email
//             manager.SendOrderConfirmation("cliente@email.com", "12345", "email");
//             Console.WriteLine();
//
//             // Cliente 2 prefere SMS
//             manager.SendOrderConfirmation("+5511999999999", "12346", "sms");
//             Console.WriteLine();
//
//             // Cliente 3 prefere Push
//             manager.SendShippingUpdate("device-token-abc123", "BR123456789", "push");
//             Console.WriteLine();
//
//             // Cliente 4 prefere WhatsApp
//             manager.SendPaymentReminder("+5511888888888", 150.00m, "whatsapp");
//
//             // Perguntas para reflexão:
//             // - Como adicionar novos tipos de notificação (Telegram, Slack) sem modificar NotificationManager?
//             // - Como evitar duplicação da lógica condicional em cada método?
//             // - Como permitir que subclasses decidam qual tipo de notificação criar?
//             // - Como tornar o código mais extensível e manutenível?
//         }
//     }
// }
