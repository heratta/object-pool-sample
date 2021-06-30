using UnityEngine;

namespace Helab.Movement
{
    [DefaultExecutionOrder(10)]
    public class StandardMovement : AbstractMovement
    {
        protected override void StartMovement()
        {
            // nothing
        }

        protected override void UpdateMovement(Vector3 deltaMovement)
        {
            var newPosition = transform.position + deltaMovement;
            transform.position = newPosition;
        }
    }
}
