using UnityEngine;

namespace Assets.Scripts.NPCs
{
    public class InitiateConversationDialogMessage
    {
        public GameObject GameObject { get; set; }
        public Sprite Portrait { get; set; }

        public InitiateConversationDialogMessage(GameObject gameObject, Sprite portrait)
        {
            GameObject = gameObject;
            Portrait = portrait;
        }
    }
}