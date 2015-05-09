using Assets.Scripts.Messages;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Shared
{
    public class NonPlayerGameObject : MonoBehaviour, IListener<PlayerIsRunningMessage>, IListener<PlayerIsStillMessage>
    {
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
                MoveLeft();
            }
        }

        void OnDestroy()
        {
            this.UnRegister<PlayerIsRunningMessage>();
            this.UnRegister<PlayerIsStillMessage>();
        }

        private void MoveLeft()
        {
            transform.Translate(-Speed*Time.deltaTime, 0, 0);
        }

        public void Handle(PlayerIsRunningMessage message)
        {
                        _isMoving = true;
        }

        public void Handle(PlayerIsStillMessage message)
        {
                        _isMoving = false;
        }
    }
}
