using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.NPCs
{
    public class Girl : MonoBehaviour
    {
        public Sprite Portrait;

        // Use this for initialization
        void Start () {
	
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("OnTriggerEnter2D has occurred.");
            EventAggregator.SendMessage(new InitiateConversationDialogMessage(this.gameObject, Portrait));
        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
