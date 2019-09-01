namespace Draft.Web.ViewModels
{
    public class TeamClaimViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public bool Claimed { get; set; } = false;
    }
}