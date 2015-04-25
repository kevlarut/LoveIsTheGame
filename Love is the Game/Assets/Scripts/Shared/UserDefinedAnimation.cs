using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Shared
{
    public class UserDefinedAnimation
    {
        public float? FramesPerSecond { get; set; }
        public List<Sprite> Sprites { get; set; }
    }
}