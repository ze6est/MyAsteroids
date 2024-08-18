using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    public class Ship : MonoBehaviour
    {
        private ShipInputs _shipInputs;
        
        [Inject]
        public void Construct(ShipInputs shipInputs) => 
            _shipInputs = shipInputs;

        private void OnEnable() => 
            _shipInputs.Enable();

        private void OnDisable() => 
            _shipInputs.Disable();
    }
}