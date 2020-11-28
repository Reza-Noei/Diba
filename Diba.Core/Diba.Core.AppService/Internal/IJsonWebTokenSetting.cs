namespace Diba.Core.AppService
{
    public interface IJsonWebTokenSetting
    {
        long LifeTime { get; }
        string Secret { get; }
    }
}
