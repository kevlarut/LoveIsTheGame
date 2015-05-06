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

        void Start()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<CouchBoxAnimations>();

            _animationController.PlayAnimation(_animations.Nintendo, FramesPerSecond, RepetitionMode.Infinite);
        }

        void Update()
        {
        }

        void OnDestroy()
        {
        }
    }
}