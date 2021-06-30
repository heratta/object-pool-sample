using System.Linq;
using Helab.Energy;
using UnityEngine;

namespace Helab.Movement
{
    public abstract  class AbstractMovement : MonoBehaviour
    {
        private AbstractKineticEnergy[] _kineticEnergies;
        
        private void Start()
        {
            _kineticEnergies = GetComponents<AbstractKineticEnergy>();
            StartMovement();
        }
        
        private void Update()
        {
            var deltaMovement = _kineticEnergies.Aggregate(
                Vector3.zero,
                (current, ke) => current + ke.DeltaMovement);
            UpdateMovement(deltaMovement);
        }

        protected abstract void StartMovement();
        
        protected abstract void UpdateMovement(Vector3 deltaMovement);
    }
}
