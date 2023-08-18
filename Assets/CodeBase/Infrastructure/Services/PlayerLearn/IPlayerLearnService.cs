namespace Assets.CodeBase.Infrastructure.Services.PlayerLearn
{
    public interface IPlayerLearnService : IService
    {
        public bool NewPlayerLoaded { get; set; }
        void StartLearn();
    }
}
