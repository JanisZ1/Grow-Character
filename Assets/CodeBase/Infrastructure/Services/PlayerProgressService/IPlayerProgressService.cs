namespace Assets.CodeBase.Infrastructure.Services.PlayerProgressService
{
    public interface IPlayerProgressService : IService
    {
        public PlayerProgress Progress { get; set; }
    }
}
