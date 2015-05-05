using Assets.Scripts.Shared;
using Assets.Scripts.Shared.Enumerations;
using UnityEngine;

namespace Assets.Scripts.NPCs
{
    public class Seagull : MonoBehaviour
    {
        public float Speed;

        private AnimationController _animationController;
        private SeagullAnimations _animations;
        private const float DefaultFramesPerSecond = 10f;

        // Use this for initialization
        void Start()
        {
            _animationController = GetComponent<AnimationController>();
            _animations = GetComponent<SeagullAnimations>();

            _animationController.PlayAnimation(_animations.Flying, DefaultFramesPerSecond, RepetitionMode.Infinite);
            
            var y = Random.Range(-0.5f, 0.4f);
            transform.Translate(0, y, 0);

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
    }
}