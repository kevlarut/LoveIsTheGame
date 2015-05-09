using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Messages;
using Assets.Scripts.Player;
using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.UI
{
    public class PsychadelicDanceBackground : MonoBehaviour
    {
        public int Speed;

        private AnimationController _animationController;
        private PsychadelicDanceBackgroundAnimations _animations;
        private const float DefaultFramesPerSecond = 2.37f;

        private float _red = 1f;
        private float _green = 0f;
        private float _blue = 0f;
        private ColorTransition _colorTransition = ColorTransition.RedToOrange;

        void Start()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<PsychadelicDanceBackgroundAnimations>();

            _animationController.PlayAnimation(_animations.Flickering, DefaultFramesPerSecond, RepetitionMode.Infinite);
        }

        void OnDestroy()
        {
        }

        void Update()
        {
            switch (_colorTransition)
            {
                case ColorTransition.RedToOrange:
                    if (_red >= 1f && _green < .5f)
                    {
                        _green += Time.deltaTime*Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.OrangeToYellow;
                    }
                    break;
                case ColorTransition.OrangeToYellow:
                    if (_green < 1f)
                    {
                        _green += Time.deltaTime*Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.YellowToGreen;
                    }
                    break;
                case ColorTransition.YellowToGreen:
                    if (_red > 0f)
                    {
                        _red -= Time.deltaTime*Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.GreenToBlue;
                    }
                    break;
                case ColorTransition.GreenToBlue:
                    if (_green > 0f && _blue < 1f)
                    {
                        _green -= Time.deltaTime*Speed;
                        _blue += Time.deltaTime*Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.BlueToViolet;
                    }
                    break;
                case ColorTransition.BlueToViolet:
                    if (_red < 1f)
                    {
                        _red += Time.deltaTime * Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.VioletToRed;
                    }
                    break;
                case ColorTransition.VioletToRed:
                    if (_blue > 0)
                    {
                        _blue -= Time.deltaTime*Speed;
                    }
                    else
                    {
                        _colorTransition = ColorTransition.RedToOrange;
                    }
                    break;
            }

            Color color;
            color = new Color(_red, _green, _blue);
            foreach (var spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = color;
            }
        }
    }
}
