using Cysharp.Threading.Tasks;

namespace MyAsteroids.CodeBase.Services.RemoteConfig
{
    public interface IRemoteConfig
    {
        UniTask GetRemoteConfigsAsync();
    }
}