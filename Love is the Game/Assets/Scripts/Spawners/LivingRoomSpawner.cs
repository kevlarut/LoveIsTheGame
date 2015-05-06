using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Spawners
{
	public class LivingRoomSpawner : MonoBehaviour, IListener<EverybodyDanceMessage>
	{
		public GameObject GameObject;

        void Start()
        {
            this.Register<EverybodyDanceMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<EverybodyDanceMessage>();
        }

        void Update()
        {
        }

	    public void Handle(EverybodyDanceMessage message)
        {
            Instantiate(GameObject);
	    }
	}
}
