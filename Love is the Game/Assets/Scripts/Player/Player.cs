﻿using System.Collections.Generic;
using Assets.Scripts.Messages;
using Assets.Scripts.NPCs;
using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;
using System.Collections;
using UnityEventAggregator;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour, IListener<AnimationChangedMessage>, IListener<InitiateConversationDialogMessage>, IListener<EverybodyDanceMessage>, IListener<ThePartyIsOverMessage>
    {
    
        private PlayerState _playerState = PlayerState.Standing;
        private AnimationController _animationController;
        private PlayerAnimations _animations;
        private const float DefaultFramesPerSecond = 16f;

        // Use this for initialization
        void Start ()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<PlayerAnimations>();

            ChangeState(PlayerState.Running);

            this.Register<AnimationChangedMessage>();
			this.Register<EverybodyDanceMessage>();
            this.Register<InitiateConversationDialogMessage>();
            this.Register<ThePartyIsOverMessage>();
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
				EventAggregator.SendMessage(new EverybodyDanceMessage(GirlType.Atari));
            }
        }

        void OnDestroy()
        {
            this.UnRegister<AnimationChangedMessage>();
			this.UnRegister<EverybodyDanceMessage>();
            this.UnRegister<InitiateConversationDialogMessage>();
            this.UnRegister<ThePartyIsOverMessage>();
        }

        public void Handle(AnimationChangedMessage message)
        {
            if (message.GameObject == this.gameObject)
            {
                var playerState = InferPlayerStateFromAnimation(message.NewAnimation);

                if (playerState == PlayerState.Dancing)
                {
					EventAggregator.SendMessage(new EverybodyDanceMessage(GirlType.Atari));
                }

                //EventAggregator.SendMessage(new PlayerStateChangedMessage(playerState));
            }
        }

        private void ChangeState(PlayerState playerState)
        {
            _playerState = playerState;

            var framesPerSecond = DefaultFramesPerSecond;
            var repetitionMode = RepetitionMode.Infinite;
            var newAnimation = InferAnimationFromPlayerState(playerState);

            if (playerState == PlayerState.Dancing) {
                framesPerSecond = 5;
                repetitionMode = RepetitionMode.Twice;
            }

            if (playerState == PlayerState.Running)
            {
                EventAggregator.SendMessage(new PlayerIsRunningMessage());
            }
            else
            {
                EventAggregator.SendMessage(new PlayerIsStillMessage());
            }

            _animationController.PlayAnimation(newAnimation, framesPerSecond, repetitionMode);
        }
        
        //TODO: Combine the shared logic of this method and the other Inference method
        private List<Sprite> InferAnimationFromPlayerState(PlayerState playerState)
        {
            var inferredAnimation = _animations.Standing;
            switch (playerState)
            {
                case PlayerState.Dancing:
                    inferredAnimation = _animations.Dancing;
                    break;
                case PlayerState.Running:
                    inferredAnimation = _animations.Running;
                    break;
            }

            return inferredAnimation;
        }

        //TODO: This method is gross.  Can I do this in a more humane manner?
        //Why is this cludge even necessary?  Can't I change AnimationController to
        //give me something other than just the gameObject and the newAnimation?
        private PlayerState InferPlayerStateFromAnimation(List<Sprite> newAnimation)
        {
            var inferredPlayerState = PlayerState.Standing;
            
            if (newAnimation != null && newAnimation.Count > 1)
            {
                switch (newAnimation[1].name)
                {
                    case "running-02":
                        inferredPlayerState = PlayerState.Running;
                        break;
                    case "dancing-up":
                        inferredPlayerState = PlayerState.Dancing;
                        break;
                }
            }

            return inferredPlayerState;
        }

        private void StandStill()
        {
            _animationController.PlayAnimation(_animations.Standing, DefaultFramesPerSecond, RepetitionMode.Infinite);
            EventAggregator.SendMessage(new PlayerIsStillMessage());
        }

        public void Handle(InitiateConversationDialogMessage message)
        {
            StandStill();
        }

	    public void Handle(EverybodyDanceMessage message)
	    {
			ChangeState(PlayerState.Dancing);
	    }

	    public void Handle(ThePartyIsOverMessage message)
        {
            ChangeState(PlayerState.Running);
	    }
    }
}