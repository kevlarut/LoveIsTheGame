using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.NPCs
{
    public class InitiateConversationDialogMessage
    {
        public GameObject GameObject { get; set; }
        public Sprite Portrait { get; set; }
	    public List<Sprite> ConversationTextSprites { get; set; }

	    public InitiateConversationDialogMessage(GameObject gameObject, Sprite portrait, List<Sprite> conversationTextSprites)
        {
            GameObject = gameObject;
            Portrait = portrait;
	        ConversationTextSprites = conversationTextSprites;
        }
    }
}