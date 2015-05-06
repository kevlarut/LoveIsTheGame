using System.Collections.Generic;
using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.UI
{
    public class Conversation : MonoBehaviour
    {
        public SpriteRenderer GirlPortrait;
	    public SpriteRenderer PlayerPortrait;
	    public SpriteRenderer Text;
	    public float TimeToShowText;

	    private List<Sprite> _textSprites;
	    private int _currentTextSpriteIndex = 0;
	    private float _elapsedTime = 0;

        void Start () {
            this.Register<InitiateConversationDialogMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<InitiateConversationDialogMessage>();
        }
	
        void Update()
        {
		    _elapsedTime += Time.deltaTime;
		    if (_elapsedTime > TimeToShowText)
		    {
			    if (!ChangeToNextTextSprite())
				{
                    EventAggregator.SendMessage(new HaveAHeartMessage());
					EventAggregator.SendMessage(new EverybodyDanceMessage());
					Destroy(gameObject);
			    }

				_elapsedTime = 0;
		    }

		    if (Input.GetKeyDown(KeyCode.Space))
			{
				Destroy(gameObject);
		    }
        }

	    private bool ChangeToNextTextSprite()
	    {
		    if (_textSprites != null && _textSprites.Count > _currentTextSpriteIndex + 1)
		    {
			    _currentTextSpriteIndex++;
			    Text.sprite = _textSprites[_currentTextSpriteIndex];

			    if (_currentTextSpriteIndex%2 == 0)
			    {
				    ShowPlayerPortrait();
			    }
			    else
			    {
				    ShowGirlPortrait();
			    }

			    return true;
		    }
		    else
		    {
			    return false;
		    }
	    }

	    private void ShowPlayerPortrait()
		{
			GirlPortrait.GetComponent<Renderer>().enabled = false;
			PlayerPortrait.GetComponent<Renderer>().enabled = true;
			Text.transform.Translate(0.25f, 0, 0);
		}

		private void ShowGirlPortrait()
		{
			GirlPortrait.GetComponent<Renderer>().enabled = true;
			PlayerPortrait.GetComponent<Renderer>().enabled = false;
			Text.transform.Translate(-0.5f, 0, 0);
	    }

	    public void LoadConversationFromMessage(InitiateConversationDialogMessage message)
		{
			_currentTextSpriteIndex = -1;
			GirlPortrait.sprite = message.Portrait;
			if (message.ConversationTextSprites.Count > 0)
			{
				_textSprites = message.ConversationTextSprites;
				ChangeToNextTextSprite();
			}
			else
			{
				Destroy(gameObject);
			}
	    }
    }
}
