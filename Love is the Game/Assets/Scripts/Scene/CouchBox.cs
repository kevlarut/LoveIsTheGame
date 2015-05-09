using System.Collections.Generic;
using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using Assets.Scripts.Player;
using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;

namespace Assets.Scripts.Scene
{
    public class CouchBox : MonoBehaviour
    {
        public float FramesPerSecond;

        private AnimationController _animationController;
        private CouchBoxAnimations _animations;
        private List<Sprite> _currentAnimation;

        void Start()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<CouchBoxAnimations>();

            if (_currentAnimation == null)
            {
                _currentAnimation = _animations.Nintendo;
            }

            _animationController.PlayAnimation(_currentAnimation, FramesPerSecond, RepetitionMode.Infinite);
        }

        void Update()
        {
        }

        void OnDestroy()
        {
        }

        public void LoadCouchBoxAnimation(GirlType girl)
        {
            var animations = GetComponent<CouchBoxAnimations>();

            switch (girl)
            {
                case GirlType.Atari:
                    _currentAnimation = animations.Atari;
                    break;
                case GirlType.Nintendo:
                    _currentAnimation = animations.Nintendo;
                    break;
                case GirlType.Sega:
                    _currentAnimation = animations.Sega;
                    break;
                default:
                    _currentAnimation = animations.Xbox;
                    break;
            }
        }
    }
}