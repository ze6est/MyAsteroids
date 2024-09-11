using MyAsteroids.CodeBase.Ships;
using UnityEngine;

namespace MyAsteroids.CodeBase.Configs
{
    [CreateAssetMenu(menuName = "Create ship", fileName = "Ship", order = 51)]
    public class ShipConfig : ScriptableObject
    {
        public Ship ShipPrefab;
    }
}
