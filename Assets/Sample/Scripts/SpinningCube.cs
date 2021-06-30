using Helab.Energy;
using Helab.Movement;
using UnityEngine;
using UnityEngine.Pool;

namespace Sample
{
    [RequireComponent(typeof(StandardMovement))]
    [RequireComponent(typeof(GravityEnergy))]
    [RequireComponent(typeof(JumpEnergy))]
    public class SpinningCube : MonoBehaviour
    {
        private IObjectPool<SpinningCube> _pool;

        private Renderer _renderer;

        private JumpEnergy _jumpEnergy;

        private float _rotateAngle;
        
        private Vector3 _rotateAxis;

        public void Initialize(IObjectPool<SpinningCube> pool)
        {
            _pool = pool;
            _renderer = GetComponent<Renderer>();
            _jumpEnergy = GetComponent<JumpEnergy>();
        }

        public void Configure()
        {
            transform.position = new Vector3(0f, 1f, 0f);
            
            _renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            
            var rangeXZ = Random.insideUnitCircle * 0.5f;
            var direction = new Vector3(rangeXZ.x, 1f, rangeXZ.y);
            _jumpEnergy.JumpDirection = direction.normalized;
            _jumpEnergy.jumpSpeed = Random.Range(7f, 12f);

            _rotateAngle = 0f;
            _rotateAxis = Random.insideUnitSphere;
        }

        private void Update()
        {
            if (_pool == null)
            {
                return;
            }
            
            if (transform.position.y <= 0.0f)
            {
                _pool.Release(this);
            }

            _rotateAngle += 360f * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(_rotateAngle, _rotateAxis);
        }
    }
}
