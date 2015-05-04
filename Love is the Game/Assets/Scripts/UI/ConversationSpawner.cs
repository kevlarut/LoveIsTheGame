using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEventAggregator;
using Random = System.Random;

namespace Assets.Scripts.Scene
{
	public class ConversationSpawner : MonoBehaviour, IListener<InitiateConversationDialogMessage>
	{
		public GameObject ConversationGameObject;

        void Start()
        {
			this.Register<InitiateConversationDialogMessage>();
        }

        void OnDestroy()
        {
			this.UnRegister<InitiateConversationDialogMessage>();
        }

        void Update()
        {
        }
		
		public void Handle(InitiateConversationDialogMessage message)
		{
			var newGameObject = Instantiate(ConversationGameObject);
			newGameObject.GetComponent<Conversation>().LoadConversationFromMessage(message);
		}
    }
}
