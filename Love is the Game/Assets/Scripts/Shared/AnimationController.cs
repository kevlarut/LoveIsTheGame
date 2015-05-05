using System.Collections.Generic;
using Assets.Scripts.Messages;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Shared
{
    public class AnimationController : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;

        private List<Sprite> _currentAnimation;
        private List<Sprite> _animationToPlayAfterThisOne;
        private List<Sprite> _animationToPlayAfterNextOne;

        public float FramesPerSecond;

        private int _currentFrame;
        private float _timeOnFrame;
        private float? _framesPerSecondAfterThisOne;
        private float? _framesPerSecondAfterNextOne;
        private RepetitionMode _repetitionMode;

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
                    if (_animationToPlayAfterThisOne != null)
                    {
                        if (_repetitionMode != RepetitionMode.Twice)
                        {
                            EventAggregator.SendMessage(new AnimationChangedMessage(_animationToPlayAfterThisOne,
                                                                                    this.gameObject));
                        }
                        _currentAnimation = _animationToPlayAfterThisOne;

                        if (_animationToPlayAfterNextOne == null)
                        {
                            _animationToPlayAfterThisOne = null;
                        }
                        else
                        {
                            _animationToPlayAfterThisOne = _animationToPlayAfterNextOne;
                            _animationToPlayAfterNextOne = null;
                        }

                        if (_framesPerSecondAfterThisOne.HasValue)
                        {
                            FramesPerSecond = _framesPerSecondAfterThisOne.Value;

                            if (_framesPerSecondAfterNextOne == null)
                            {
                                _framesPerSecondAfterThisOne = null;
                            }
                            else
                            {
                                _framesPerSecondAfterThisOne = _framesPerSecondAfterNextOne;
                                _framesPerSecondAfterNextOne = null;
                            }
                        }
                    }
                }
            }

            SpriteRenderer.sprite = _currentAnimation[_currentFrame];
        }

        public void PlayAnimation(List<Sprite> anim, float framesPerSecond, RepetitionMode repetitionMode)
        {
            _repetitionMode = repetitionMode;

            switch (repetitionMode)
            {
                case RepetitionMode.Once:
                    _animationToPlayAfterThisOne = _currentAnimation;
                    _framesPerSecondAfterThisOne = FramesPerSecond;
                    _animationToPlayAfterNextOne = null;
                    _framesPerSecondAfterNextOne = null;
                    break;
                case RepetitionMode.Twice:
                    _animationToPlayAfterThisOne = anim;
                    _framesPerSecondAfterThisOne = framesPerSecond;
                    _animationToPlayAfterNextOne = _currentAnimation;
                    _framesPerSecondAfterNextOne = FramesPerSecond;
                    break;
                default:
                    _animationToPlayAfterThisOne = null;
                    _animationToPlayAfterNextOne = null;
                    _framesPerSecondAfterThisOne = null;
                    _framesPerSecondAfterNextOne = null;
                    break;
            }

            FramesPerSecond = framesPerSecond;

            _currentAnimation = anim;
            _currentFrame = 0;
        }
    }
}