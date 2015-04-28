using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public class SeagullSpawner : MonoBehaviour
    {
        public float MinSpawnDelay;
        public float MaxSpawnDelay;

        private float _currentSpawnDelay;

        public GameObject SeagullGameObject;

        void Start()
        {
            _currentSpawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        }

        void Update()
        {
            _currentSpawnDelay -= Time.deltaTime;

            if (_currentSpawnDelay <= 0)
            {
                _currentSpawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
                Instantiate(SeagullGameObject);
            }
        }
    }
}