using Assets.CodeBase.Infrastructure.StaticData;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Logic.Ui
{
    public class HeightShowBuildingUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _heightText;

        public void InitializeTextWith(HeightShowBuildingData heightShowBuildingData) => 
            _heightText.text = $"{heightShowBuildingData.Height}";
    }
}
