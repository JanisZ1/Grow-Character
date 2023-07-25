using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService
{
    public interface IUiFactory : IService
    {
        void CreateUiRoot();
        GameObject CreateShop();
    }
}
