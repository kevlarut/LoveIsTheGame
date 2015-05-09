using System.Collections.Generic;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;

namespace Assets.Scripts.NPCs
{
    public class InitiateConversationDialogMessage
    {
        public GameObject GameObject { get; set; }
        public Sprite Portrait { get; set; }
	    public List<Sprite> ConversationTextSprites { get; set; }
        public GirlType GirlType { get; set; }

        public InitiateConversationDialogMessage(GameObject gameObject, Sprite portrait, List<Sprite> conversationTextSprites, GirlType girlType)
        {
            GameObject = gameObject;
            GirlType = girlType;
            Portrait = portrait;
	        ConversationTextSprites = conversationTextSprites;
        }
    }
}