using System.Collections.Generic;
using System.Linq;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class DivChampPhaseService : IHandle<DivChampPhaseEvent>
    {
        private readonly ITimerService _timerService;
        private readonly IRepository _repository;
        private readonly Season _season;

        public DivChampPhaseService(ITimerService timerService,
                                    IRepository repository)
        {
            _timerService = timerService;
            _repository = repository;
            _season = _repository.Get(new CurrentSeasonWithStandingsTeams());
        }
        public void Handle(DivChampPhaseEvent domainEvent)
        {
            _timerService.StartTimer(10, new PhaseTimerEndedEvent());

            var standings = _season.Standings;
            standings.EastChamp = CalcFirstPlace(standings.EastStandings);
            standings.WestChamp = CalcFirstPlace(standings.WestStandings);
            _repository.Update(standings);
        }

        private ArcTeam CalcFirstPlace(List<ArcTeam> teams)
        {
            var bestRecord = teams.First().Record;
            var firstPlaceTeams = teams.Where(t => t.Record.Equals(bestRecord)).ToList();
            if (firstPlaceTeams.Count() == 1)
                return firstPlaceTeams.First();
            return PlayTieBreakers(firstPlaceTeams);
        }

        private ArcTeam PlayTieBreakers(List<ArcTeam> contenders)
        {
            while (contenders.Count() > 1)
            {
                for (int i = 0; i < contenders.Count(); i += 2)
                {
                    if (contenders.Count() % 2 != 0)
                        i++;
                    Team loser = null;
                    while (loser == null)
                    {
                        var tieBreaker = new Game(
                            _season.CurDate,
                            contenders[i].Team,
                            contenders[i + 1].Team);

                        tieBreaker.Play();
                        _repository.Add(tieBreaker);
                        loser = tieBreaker.Loser;
                    }
                    contenders.Remove(contenders.Single(at => at.Team.Id == loser.Id));
                }
            }
            return contenders.First();
        }
    }
}