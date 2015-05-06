using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class DancingFool : MonoBehaviour
    {
        public float VerticalDriftSpeed;

        private AnimationController _animationController;
        private PlayerAnimations _animations;
        private const float DefaultFramesPerSecond = 16f;

        void Start()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<PlayerAnimations>();
            _animationController.PlayAnimation(_animations.Dancing, 5, RepetitionMode.Infinite);
        }

        void Update()
        {
            var yTranslation = -VerticalDriftSpeed*Time.deltaTime;
            transform.Translate(0, yTranslation, 0);

            if (transform.position.y <= -3)
            {
                transform.Translate(0, 4, 0);
            }
        }

        void OnDestroy()
        {
        }
    }
}