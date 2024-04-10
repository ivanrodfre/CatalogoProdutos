using Flunt.Notifications;
using Catalogo.Commands.Contracts;

namespace Catalogo.Domain.Commands
{
    public abstract class CommandBase : Notifiable<Notification>, ICommand
    {
    }
}
