using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "BackgroundSoundData", menuName = "StaticData/BackgroundSoundData")]
    public class BackgroundSoundStaticData : ScriptableObject
    {
        public GameObject Prefab;
        public int Id;
    }
}