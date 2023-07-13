using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssets _assets;

        public HeroFactory(IAssets assets) =>
            _assets = assets;

        public void CreateHero(Vector3 at)
        {
            _assets.Instantiate(AssetPath.HeroPath, at);
        }
    }
}
