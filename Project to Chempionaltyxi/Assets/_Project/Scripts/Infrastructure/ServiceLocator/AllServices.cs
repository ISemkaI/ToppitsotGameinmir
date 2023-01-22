// Simple service-locator
public class AllServices
{
    private static AllServices _instance;

    public static AllServices Instance => _instance ??= new AllServices();

    public void RegisterService<TService>(TService implementation) where TService : IService
        => Implementation<TService>.Container = implementation;

    public TService GetService<TService>() where TService : IService
        => Implementation<TService>.Container;

    private class Implementation<TService> where TService : IService
    {
        public static TService Container;
    }
}
