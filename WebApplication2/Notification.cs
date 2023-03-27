using MediatR;

namespace WebApplication2;

//Standaard gebeurt niet parallel maar na elkaar
//Parallele executie wel mogelijk

//Onthou => notificaties 0 - x aantal handlers
//Request => Requests 1 handler
internal class Notification : INotification {
    //Mag ook leeg zijn
    public int id { get; set; }

}

internal class NotificationTest : INotificationHandler<Notification>
{
    public async Task Handle(Notification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(2000);
        Console.WriteLine($"{DateTime.Now.ToLocalTime()} Ik ben de eerste handler van de notificaties");
    }
}

internal class NotificationTest2 : INotificationHandler<Notification>
{
    public async Task Handle(Notification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now.ToLocalTime()} Ik ben de tweede handler van de notificaties");
    }
}

