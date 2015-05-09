using Assets.Scripts.Messages;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Scene
{
    public class RepeatScroller : MonoBehaviour, IListener<PlayerIsRunningMessage>, IListener<PlayerIsStillMessage>
    {
        public float Length;
        public float Speed;

        private bool _isMoving = true;

        // Use this for initialization
        void Start()
        {
            this.Register<PlayerIsRunningMessage>();
            this.Register<PlayerIsStillMessage>();
        }
	
        // Update is called once per frame
        void Update () {

            if (_isMoving)
            {
                ResetPositionIfExhausted();
            }
        }

        void OnDestroy()
        {
            this.UnRegister<PlayerIsRunningMessage>();
            this.UnRegister<PlayerIsStillMessage>();
        }

        public void Handle(PlayerIsRunningMessage message)
        {
            _isMoving = true;
        }

        public void Handle(PlayerIsStillMessage message)
        {
            _isMoving = false;
        }

        private void ResetPositionIfExhausted()
        {
            if (transform.position.x <= -Length)
            {
                transform.Translate(Length, 0, 0);
            }
        }
    }
}
