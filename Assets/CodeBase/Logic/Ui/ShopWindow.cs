using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.ShopCache;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Ui
{
    public class ShopWindow : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private Scrollbar _scrollBar;
        private IShopCachedObjectService _shopCachedObjectService;

        public void Construct(IShopCachedObjectService shopCachedObjectService) => 
            _shopCachedObjectService = shopCachedObjectService;

        public void Close() =>
            _shopCachedObjectService.Disable();

        public void SaveProgress(PlayerProgress progress) =>
            progress.ShopUiData.ScrollBarValue = _scrollBar.value;

        public void LoadProgress(PlayerProgress progress) =>
            _scrollBar.value = progress.ShopUiData.ScrollBarValue;
    }
}
