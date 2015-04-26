using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Shared
{
    public class NonPlayerGameObject : MonoBehaviour, IListener<PlayerStateChangedMessage>
    {
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
                MoveLeft();
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

        private void MoveLeft()
        {
            transform.Translate(-Speed*Time.deltaTime, 0, 0);
        }
    }
}
