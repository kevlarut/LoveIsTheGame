using Assets.Scripts.Messages;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Scene
{
    public class LivingRoom : MonoBehaviour, IListener<ThePartyIsOverMessage>
    {
        void Start()
        {
            this.Register<ThePartyIsOverMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<ThePartyIsOverMessage>();
        }

        void Update()
        {
        }

        public void Handle(ThePartyIsOverMessage message)
        {
            Destroy(gameObject);
        }
    }
}
