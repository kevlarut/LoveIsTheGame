using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Messages;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;
using Random = System.Random;

namespace Assets.Scripts.Scene
{
    class DoodadSpawner : MonoBehaviour, IListener<PlayerStateChangedMessage>
    {
        public float MinSpawnDelay;
        public float MaxSpawnDelay;

        private float _currentSpawnDelay;
        private int _previousDoodadIndex = -1;

        public List<GameObject> Doodads;
        private bool _enableSpawning = true;

        void Start()
        {
            this.Register<PlayerStateChangedMessage>();
            _currentSpawnDelay = UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay);
        }

        void OnDestroy()
        {
            this.UnRegister<PlayerStateChangedMessage>();
        }

        void Update()
        {
            if (_enableSpawning)
            {
                _currentSpawnDelay -= Time.deltaTime;

                if (_currentSpawnDelay <= 0)
                {
                    _currentSpawnDelay = UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay);
                    Instantiate(GetRandomCurbDoodad());
                }
            }
        }

        private Object GetRandomCurbDoodad()
        {
            var index = UnityEngine.Random.Range(0, Doodads.Count);

            if (Doodads.Count > 1 && index == _previousDoodadIndex)
            {
                index++;
                if (index > _previousDoodadIndex)
                {
                    index = 0;
                }
            }

            _previousDoodadIndex = index;

            return Doodads[index];
        }

        public void Handle(PlayerStateChangedMessage message)
        {
            switch (message.PlayerState)
            {
                case PlayerState.Running:
                    _enableSpawning = true;
                    break;
                default:
                    _enableSpawning = false;
                    break;
            }
        }
    }
}
