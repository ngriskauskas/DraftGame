using AutoMapper;
using Draft.Core.Entities;
using Draft.Web.ViewModels;

namespace Draft.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Season, SeasonViewModel>();
            CreateMap<Phase, PhaseViewModel>();
            CreateMap<Standings, StandingsViewModel>();
            CreateMap<ArcTeam, StandingsTeamViewModel>();
            CreateMap<Player, PlayerViewModel>();
            CreateMap<Waiver, WaiverViewModel>();
            CreateMap<Team, TeamViewModel>();
            CreateMap<Team, TeamClaimViewModel>();
        }
    }
}