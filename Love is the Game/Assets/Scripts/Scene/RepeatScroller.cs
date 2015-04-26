using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Scene
{
    public class RepeatScroller : MonoBehaviour, IListener<PlayerStateChangedMessage>
    {
        public float Length;
        public float Speed;

        private bool _isMoving = true;

        // Use this for initialization
        void Start()
        {
            this.Register<PlayerStateChangedMessage>();
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
            this.UnRegister<PlayerStateChangedMessage>();
        }

        public void Handle(PlayerStateChangedMessage message)
        {
            switch (message.PlayerState)
            {
                case PlayerState.Running:
                    _isMoving = true;
                    break;
                default:
                    _isMoving = false;
                    break;
            }
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
