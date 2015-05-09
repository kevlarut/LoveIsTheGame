using System.Collections.Generic;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.NPCs
{
    public class Girl : MonoBehaviour
    {
        public Sprite Portrait;
	    public List<Sprite> ConversationTextSprites;
        public GirlType GirlType;

        // Use this for initialization
        void Start () {
	
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("OnTriggerEnter2D has occurred.");
			EventAggregator.SendMessage(new InitiateConversationDialogMessage(this.gameObject, Portrait, ConversationTextSprites, GirlType));
        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
