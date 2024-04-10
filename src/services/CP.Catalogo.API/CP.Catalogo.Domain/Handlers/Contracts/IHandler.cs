using Catalogo.Commands.Contracts;

namespace Catalogo.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }

    public interface IHandlerAsync<T> where T : ICommand
    {
        Task<ICommandResult> Handler(T command);
    }
}
