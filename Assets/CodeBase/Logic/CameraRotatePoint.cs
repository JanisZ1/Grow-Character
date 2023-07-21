using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CameraRotatePoint : MonoBehaviour
    {
        private IHeroHandler _heroHandler;

        public void Construct(IHeroHandler heroHandler) =>
            _heroHandler = heroHandler;

        private void LateUpdate()
        {
            transform.position = _heroHandler.HeroGameObject.transform.position;
            transform.localScale = _heroHandler.HeroGameObject.transform.localScale;
        }
    }
}