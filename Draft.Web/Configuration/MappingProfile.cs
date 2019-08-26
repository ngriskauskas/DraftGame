using AutoMapper;
using Draft.Core.Entities;
using Draft.Web.Api;

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

        }


    }


}