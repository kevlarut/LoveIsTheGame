using Assets.Scripts.Messages;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Scene
{
    public class ChorusExpirationTimer : MonoBehaviour
    {
        public float TimeToLive;

        private float _timeElapsed;

        void Start()
        {
        }

        void OnDestroy()
        {
        }

        void Update()
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed > TimeToLive)
            {
                EventAggregator.SendMessage(new ThePartyIsOverMessage());
                Destroy(gameObject);
            }
        }
    }
}
