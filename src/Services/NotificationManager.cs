using src.Enum;
using src.Interfaces;
using src.Models;

namespace src.Services;

public class NotificationManager
{
    public void SendOrderConfirmation(INotification notification, NotificationRequest request)
    {
        request.Kind = NotificationKind.OrderConfirmation;
        notification.Send(request);
    }

    public void SendShippingUpdate(INotification notification, NotificationRequest request)
    {
        request.Kind = NotificationKind.ShippingUpdate;
        notification.Send(request);
    }

    public void SendPaymentReminder(INotification notification, NotificationRequest request)
    {
        request.Kind = NotificationKind.PaymentReminder;
        notification.Send(request);
    }
}