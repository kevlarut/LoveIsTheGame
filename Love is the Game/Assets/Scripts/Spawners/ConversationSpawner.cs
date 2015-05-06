using Assets.Scripts.NPCs;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Spawners
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
