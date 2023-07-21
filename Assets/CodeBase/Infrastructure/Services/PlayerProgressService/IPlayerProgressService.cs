namespace Assets.CodeBase.Infrastructure.Services.PlayerProgressService
{
    public interface IPlayerProgressService : IService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
