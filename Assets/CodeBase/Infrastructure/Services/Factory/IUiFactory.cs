namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface IUiFactory : IService
    {
        void CreateUiRoot();
        void CreateShop();
    }
}
