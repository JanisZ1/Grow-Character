using Assets.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CameraRotatePoint : MonoBehaviour
    {
        private IHeroHandler _heroHandler;

        public void Construct(IHeroHandler heroHandler) =>
            _heroHandler = heroHandler;

        private void Update() =>
            transform.position = _heroHandler.HeroGameObject.transform.position;
    }
}