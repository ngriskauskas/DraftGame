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
            CreateMap<Waiver, WaiverViewModel>();
            CreateMap<Team, TeamViewModel>();
            CreateMap<Team, TeamClaimViewModel>();
            CreateMap<Player, PlayerViewModel>()
                .ForMember(p => p.IsStarter, opt => opt.MapFrom<IsStarterResolver>());
        }
    }
    class IsStarterResolver : IValueResolver<Player, PlayerViewModel, bool>
    {
        public bool Resolve(Player source, PlayerViewModel destination,
                            bool destMember, ResolutionContext context)
        {
            return source.Team.Starters.Contains(source);
        }
    }
}