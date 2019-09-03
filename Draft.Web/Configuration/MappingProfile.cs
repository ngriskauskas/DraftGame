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
            CreateMap<ArcTeam, TeamRecordViewModel>();
            CreateMap<Team, TeamViewModel>();
            CreateMap<Team, TeamClaimViewModel>();
            CreateMap<Record, RecordViewModel>();
            CreateMap<Player, WaiverPlayerViewModel>();
            CreateMap<Player, TeamPlayerViewModel>()
                .ForMember(p => p.IsStarter, opt => opt.MapFrom<IsStarterResolver>());
        }
    }
    class IsStarterResolver : IValueResolver<Player, TeamPlayerViewModel, bool>
    {
        public bool Resolve(Player source, TeamPlayerViewModel destination,
                            bool destMember, ResolutionContext context)
        {
            return source.Team.Starters.Contains(source);
        }
    }
}