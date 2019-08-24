using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class GameStartedEvent : DomainEvent
    {
        public Game Game { get; }
        public GameStartedEvent(Game game)
        {
            Game = game;
        }
    }
}