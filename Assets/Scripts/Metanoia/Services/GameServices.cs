namespace Assets.Scripts.Metanoia.Services
{
    public class GameServices
    {
        private static GameServices _instance;

        public static GameServices Container => _instance ?? (_instance = new GameServices());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
