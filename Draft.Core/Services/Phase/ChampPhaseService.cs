using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class ChampPhaseService : IHandle<ChampPhaseEvent>
    {
        private readonly ITimerService _timerService;
        private readonly IRepository _repository;
        private Season _season;

        public ChampPhaseService(IRepository repository, ITimerService timerService)
        {
            _timerService = timerService;
            _repository = repository;
            _season = _repository.Get(new CurrentSeasonWithStandingsTeams());
        }
        public void Handle(ChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(10, new PhaseTimerEndedEvent());
            DetermineChampion();
        }

        private void DetermineChampion()
        {
            var standings = _season.Standings;
            Team homeTeam, awayTeam;
            if (standings.EastChamp.Record > standings.WestChamp.Record)
            {
                homeTeam = standings.EastChamp.Team;
                awayTeam = standings.WestChamp.Team;
            }
            else
            {
                awayTeam = standings.EastChamp.Team;
                homeTeam = standings.WestChamp.Team;
            }

            var champGame = new Game(_season.CurDate, homeTeam, awayTeam);
            champGame.Play();
            _repository.Add(champGame);

            standings.Champion = new ArcTeam(champGame.Winner);
            _repository.Update(standings);
        }
    }
}