using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class LeagueService : IHandle<PhaseTimerEndedEvent>
    {
        private readonly IRepository _repository;

        public LeagueService(IRepository repository)
        {
            _repository = repository;
        }
        public void StartLeague()
        {
            var prevSeason = _repository.Get(new SeasonWithPhaseStandings(s => s.IsActive && !s.IsCompleted));
            prevSeason.Complete();
            _repository.Update(prevSeason);

            var newSeason = _repository.Get(new SeasonWithPhaseStandings(s => s.Id == prevSeason.Id + 1));
            newSeason.Activate();
            _repository.Update(newSeason);
        }

        private void EndPhase()
        {
            var season = _repository.Get(new SeasonWithPhaseStandings(s => s.IsActive && !s.IsCompleted));
            season.CompletePhase();
            _repository.Update(season);
        }

        public void Handle(PhaseTimerEndedEvent domainEvent)
        {
            EndPhase();
        }
    }
}