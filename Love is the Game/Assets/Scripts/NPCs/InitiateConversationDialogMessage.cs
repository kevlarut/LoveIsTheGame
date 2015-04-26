using UnityEngine;

namespace Assets.Scripts.NPCs
{
    public class InitiateConversationDialogMessage
    {
        public GameObject GameObject { get; set; }
        public InitiateConversationDialogMessage(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}