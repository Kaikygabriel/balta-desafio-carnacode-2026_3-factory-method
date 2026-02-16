using src.Models;

namespace src.Interfaces;

public interface INotification
{
    void Send(NotificationRequest request);
}