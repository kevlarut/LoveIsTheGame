using System;
using System.Collections.Generic;
using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;

namespace Assets.Scripts.Scene
{
    public class TelevisionSetAndConsole : MonoBehaviour
    {
        public List<Sprite> Sprites;

        private Sprite _currentSprite;

        void Start()
        {
            if (_currentSprite == null)
            {
                _currentSprite = Sprites[0];
            }
        }

        void Update()
        {
        }

        void OnDestroy()
        {
        }

        public void LoadSprite(GirlType girlType)
        {
            var index = (int) girlType;
            if (index > Sprites.Count - 1)
            {
                index = 0;
            }
            _currentSprite = Sprites[index];

            gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
        }
    }
}