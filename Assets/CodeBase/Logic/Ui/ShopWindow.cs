using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Ui
{
    public class ShopWindow : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private Scrollbar _scrollBar;

        public void Close() =>
            Destroy(gameObject);

        public void SaveProgress(PlayerProgress progress) =>
            progress.ShopUiData.ScrollBarValue = _scrollBar.value;

        public void LoadProgress(PlayerProgress progress) =>
            _scrollBar.value = progress.ShopUiData.ScrollBarValue;
    }
}
