using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Data
{
    public static class DataExtensions
    {
        public static string ToJson(this object progress) =>
            JsonUtility.ToJson(progress);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}
