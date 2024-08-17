using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;

namespace MyAsteroids.CodeBase
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ShipMover _ship;
        [SerializeField] private ShipData _shipData;
        
        private ShipInputs _shipInputs;
        
        private void Awake()
        {
            _shipInputs = new ShipInputs();
            _shipInputs.Enable();
            
            ShipMover ship = Instantiate(_ship);
            ship.Construct(_shipData, _shipInputs);

            ShipRotator shipRotator;

            if(ship.TryGetComponent(out shipRotator))
            {
                shipRotator.Construct(_shipData, _shipInputs);
            }
        }

        private void OnDestroy()
        {
            _shipInputs.Disable();
        }
    }
}
