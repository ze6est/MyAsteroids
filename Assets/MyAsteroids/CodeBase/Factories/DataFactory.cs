using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Services;
using Zenject;

namespace MyAsteroids.CodeBase.Factories
{
    public class DataFactory<T> : IFactory<T> where T : IData
    {
        private readonly IDataProvider _dataProvider;

        public DataFactory(IDataProvider dataProvider) => 
            _dataProvider = dataProvider;

        public T Create() => 
            _dataProvider.Load<T>();
    }
}
