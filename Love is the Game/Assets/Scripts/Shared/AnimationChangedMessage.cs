using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Shared
{
    public class AnimationChangedMessage
    {
        public readonly GameObject GameObject;
        public readonly List<Sprite> NewAnimation;

        public AnimationChangedMessage(List<Sprite> newAnimation, GameObject gameObject)
        {
            GameObject = gameObject;
            NewAnimation = newAnimation;
        }
    }
}