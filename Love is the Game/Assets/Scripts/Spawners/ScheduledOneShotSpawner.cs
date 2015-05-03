using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public class ScheduledOneShotSpawner : MonoBehaviour
    {
        public float SecondsToWaitBeforeSpawning;

        private float _currentSecondsElapsed;
        private bool _objectHasSpawned;

        public GameObject GameObject;

        void Start()
        {
            _currentSecondsElapsed = 0;
            _objectHasSpawned = false;
        }

        void Update()
        {
            if (!_objectHasSpawned)
            {
                if (_currentSecondsElapsed >= SecondsToWaitBeforeSpawning)
                {
                    Instantiate(GameObject);
                    _objectHasSpawned = true;
                }
                else
                {
                    _currentSecondsElapsed += Time.deltaTime;
                }
            }
        }
    }
}