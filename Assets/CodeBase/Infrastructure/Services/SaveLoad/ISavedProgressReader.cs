using Assets.CodeBase.Infrastructure.Data;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}
