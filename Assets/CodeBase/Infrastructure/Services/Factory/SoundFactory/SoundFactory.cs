using Assets.CodeBase.Infrastructure.Services.AssetProvider;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class SoundFactory : ISoundFactory
    {
        private readonly IAssets _assets;

        public SoundFactory(IAssets assets) =>
            _assets = assets;

        public void CreateBackgroundSound() =>
            _assets.Instantiate(AssetPath.MainBackgroundSoundPath);
    }
}
