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
            CreateMap<Player, PlayerViewModel>()
                .ForMember(p => p.IsStarter, opt => opt.MapFrom<PlayerResolver>())
                .ForMember(p => p.TeamName, opt => opt.MapFrom<PlayerResolver>());
        }
    }
    class PlayerResolver : IValueResolver<Player, PlayerViewModel, bool>,
        IValueResolver<Player, PlayerViewModel, string>
    {
        public bool Resolve(Player source, PlayerViewModel destination,
                            bool destMember, ResolutionContext context)
        {
            if (source.Team == null) return false;
            return source.Team.Starters.Contains(source);
        }

        public string Resolve(Player source, PlayerViewModel destination, string destMember, ResolutionContext context)
        {
            if (source.Team == null) return "Waiver";
            return source.Team.Name;
        }
    }
}