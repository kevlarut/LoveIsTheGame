using System.Collections.Generic;
using Assets.Scripts.Shared;
using UnityEngine;
using System.Collections;
using UnityEventAggregator;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour {
    
        private PlayerState _playerState = PlayerState.Standing;
        private AnimationController _animationController;
        private PlayerAnimations _animations;
        private const float _defaultFramesPerSecond = 10f;

        // Use this for initialization
        void Start ()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<PlayerAnimations>();

            ChangeState(PlayerState.Running);
        }

        // Update is called once per frame
        void Update () {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeState(PlayerState.Standing);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeState(PlayerState.Running);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ChangeState(PlayerState.Dancing);
            }
        }

        private void ChangeState(PlayerState playerState)
        {
            _playerState = playerState;

            var framesPerSecond = _defaultFramesPerSecond;
            var isOneShot = false;
            var newAnimation = _animations.Standing;

            switch (playerState)
            {
                case PlayerState.Dancing:
                    GoIdle();
                    framesPerSecond = 5;
                    newAnimation = _animations.Dancing;
                    isOneShot = true;
                    break;
                case PlayerState.Running:
                    newAnimation = _animations.Running;
                    break;
            }

            _animationController.PlayAnimation(newAnimation, framesPerSecond, isOneShot);
            EventAggregator.SendMessage(new PlayerStateChangedMessage(playerState));
        }

        private void GoIdle()
        {
            _animationController.PlayAnimation(_animations.Standing, _defaultFramesPerSecond);
            EventAggregator.SendMessage(new PlayerStateChangedMessage(PlayerState.Standing));
        }
    }
}