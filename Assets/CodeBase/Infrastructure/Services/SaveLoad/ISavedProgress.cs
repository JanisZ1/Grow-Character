using Assets.CodeBase.Infrastructure.Data;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void SaveProgress(PlayerProgress progress);
    }
}
