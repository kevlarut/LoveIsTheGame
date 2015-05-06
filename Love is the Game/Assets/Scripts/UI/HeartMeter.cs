using System.Collections.Generic;
using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.UI
{
    public class HeartMeter : MonoBehaviour, IListener<HaveAHeartMessage>
    {
        public SpriteRenderer SpriteRenderer;
        public List<Sprite> Sprites;

        private short _currentHearts = 0;

        void Start()
        {
            this.Register<HaveAHeartMessage>();
        }

        void Update()
        {
        }

        private void OnDestroy()
        {
            this.UnRegister<HaveAHeartMessage>();
        }

        private void Handle()
        {
        }

        public void Handle(HaveAHeartMessage message)
        {
            if (_currentHearts < Sprites.Count - 1)
            {
                _currentHearts++;
                SpriteRenderer.sprite = Sprites[_currentHearts];
            }
        }
    }
}