using Assets.Scripts.NPCs;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.UI
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
