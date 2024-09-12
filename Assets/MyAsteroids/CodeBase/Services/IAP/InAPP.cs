using UnityEngine.Purchasing;

namespace MyAsteroids.CodeBase.Services.IAP
{
    public class InAPP
    {
        public InAPP () 
        {
            //конструктор конфигурации покупки
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            
            //добавляем покурки
            builder.AddProduct("100_gold_coins", ProductType.Consumable);
            // Initialize Unity IAP...
        }
    }
}