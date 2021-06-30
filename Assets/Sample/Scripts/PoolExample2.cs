using UnityEngine;
using UnityEngine.Pool;

namespace Sample
{
    public class PoolExample2 : MonoBehaviour
    {
        [SerializeField] private SpinningCube originalCube;
        
        private IObjectPool<SpinningCube> _pool;

        private float _timeOfLastFire;

        private void Start()
        {
            _pool = new ObjectPool<SpinningCube>(
                CreatePooledCube,
                OnGetPooledCube,
                OnReleasePooledCube,
                OnDestroyPooledCube,
                true,
                10,
                10);
        }

        private void Update()
        {
            if (DoFire())
            {
                var cube = _pool.Get();
                cube.Configure();
                _timeOfLastFire = Time.realtimeSinceStartup;
            }
        }

        private bool DoFire()
        {
            return Input.GetKey(KeyCode.Space)
                   && 0.1f <= Time.realtimeSinceStartup - _timeOfLastFire;
        }

        private SpinningCube CreatePooledCube()
        {
            var cube = Instantiate(originalCube, transform, false);
            cube.Initialize(_pool);
            return cube;
        }

        private static void OnGetPooledCube(SpinningCube cube)
        {
            cube.gameObject.SetActive(true);
        }

        private static void OnReleasePooledCube(SpinningCube cube)
        {
            cube.gameObject.SetActive(false);
        }
        
        private static void OnDestroyPooledCube(SpinningCube cube)
        {
            Destroy(cube.gameObject);
        }
    }
}
