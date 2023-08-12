using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface ISoundFactory : IService
    {
        List<GameObject> CreateBackgroundSounds();
    }
}