using System;
using UnityEngine;

namespace Helab.Energy
{
    public abstract class AbstractKineticEnergy : MonoBehaviour
    {
        public bool IsEnabledUpdate { get; set; } = true;
        
        public Vector3 DeltaMovement { get; protected set; }

        private void OnEnable()
        {
            IsEnabledUpdate = true;
        }
        
        private void OnDisable()
        {
            IsEnabledUpdate = false;
            DeltaMovement = Vector3.zero;
            ResetKineticEnergy();
        }

        private void Update()
        {
            DeltaMovement = Vector3.zero;
            if (IsEnabledUpdate)
            {
                UpdateKineticEnergy(Time.deltaTime);
            }
        }

        protected abstract void ResetKineticEnergy();
        
        protected abstract void UpdateKineticEnergy(float deltaTime);
    }
}
