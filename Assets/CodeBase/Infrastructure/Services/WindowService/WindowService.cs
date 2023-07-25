using Assets.CodeBase.Infrastructure.Services.Factory;

namespace Assets.CodeBase.Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUiFactory _uiFactory;

        public WindowService(IUiFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void OpenShop() =>
            _uiFactory.CreateShop();
    }
}
