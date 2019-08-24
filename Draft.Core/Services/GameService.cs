using Draft.Core.Events;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{
    public class GameService : IHandle<GameStartedEvent>
    {
        private readonly IRepository _repository;

        public GameService(IRepository repository)
        {
            _repository = repository;
        }
        public void Handle(GameStartedEvent domainEvent)
        {
            var game = domainEvent.Game;
            game.Complete(1, 1);
        }
    }
}