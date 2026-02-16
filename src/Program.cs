using System;
using src.Models;
using src.Notifications;
using src.Services;

Console.WriteLine("=== Sistema de Notificações ===\n");

var manager = new NotificationManager();

// Cliente 1 prefere Email
var email = new EmailNotification();
manager.SendOrderConfirmation(email,new NotificationRequest()
{
    Recipient = "cliente@email.com",
    Amount = 12345
});
Console.WriteLine();

// Cliente 2 prefere SMS
var sms = new SmsNotification();
manager.SendOrderConfirmation(sms,
    new NotificationRequest()
    {
        Recipient = "5511999999999",
        Amount = 12346,
        TrackingCode = "sms"
    });
Console.WriteLine();

// Cliente 3 prefere Push
var push = new PushNotification();
manager.SendShippingUpdate(push, new NotificationRequest()
{
    Recipient = "abc123",
    Amount = 123456789,
    TrackingCode = "push"
});
Console.WriteLine();

// Cliente 4 prefere WhatsApp
var whatsapp = new WhatsAppNotification();
manager.SendPaymentReminder(whatsapp,new NotificationRequest()
{
    Recipient = "+5511888888888",
    Amount = 150,
    TrackingCode = "whatsapp"
});
