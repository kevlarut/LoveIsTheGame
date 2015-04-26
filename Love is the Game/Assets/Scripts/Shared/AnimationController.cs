using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Shared
{
    public class AnimationController : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;

        private List<Sprite> _currentAnimation;
        private List<Sprite> _previousAnimation;

        public float FramesPerSecond;

        private int _currentFrame;
        private float _timeOnFrame;
        private float? _previousFramesPerSecond;

        void Update()
        {
            if (_currentAnimation == null)
            {
                return;
            }

            _timeOnFrame += Time.deltaTime;
            if (_timeOnFrame >= 1.0 / FramesPerSecond)
            {
                _timeOnFrame = 0;
                _currentFrame++;

                if (_currentFrame >= _currentAnimation.Count)
                {
                    _currentFrame = 0;
                    if (_previousAnimation != null)
                    {
                        EventAggregator.SendMessage(new AnimationChangedMessage(_previousAnimation, this.gameObject));
                        _currentAnimation = _previousAnimation;
                        _previousAnimation = null;

                        if (_previousFramesPerSecond.HasValue)
                        {
                            FramesPerSecond = _previousFramesPerSecond.Value;
                            _previousFramesPerSecond = null;
                        }
                    }
                }
            }

            SpriteRenderer.sprite = _currentAnimation[_currentFrame];
        }

        public void PlayAnimation(List<Sprite> anim, float framesPerSecond, bool isOneShot = false)
        {
            if (isOneShot)
            {
                _previousAnimation = _currentAnimation;
                _previousFramesPerSecond = FramesPerSecond;
            }
            else
            {
                _previousAnimation = null;
                _previousFramesPerSecond = null;
            }

            FramesPerSecond = framesPerSecond;

            _currentAnimation = anim;
            _currentFrame = 0;
        }
    }
}