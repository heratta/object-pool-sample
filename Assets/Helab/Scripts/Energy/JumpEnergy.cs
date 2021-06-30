using UnityEngine;

namespace Helab.Energy
{
    public class JumpEnergy : AbstractKineticEnergy
    {
        public float jumpSpeed = 1.0f;
        
        public Vector3 JumpDirection { get; set; }
        
        protected override void ResetKineticEnergy()
        {
            jumpSpeed = 1f;
            JumpDirection = Vector3.zero;
        }

        protected override void UpdateKineticEnergy(float deltaTime)
        {
            DeltaMovement = JumpDirection * (jumpSpeed * deltaTime);
        }
    }
}
