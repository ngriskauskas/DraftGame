using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class GameCompletedEvent : DomainEvent
    {
        public Game Game { get; }
        public GameCompletedEvent(Game game)
        {
            Game = game;
        }
    }
}