using MyAsteroids.CodeBase.Data;

namespace MyAsteroids.CodeBase.Services
{
    public interface IDataProvider
    {
        public T Load<T>() where T : IData;
    }
}