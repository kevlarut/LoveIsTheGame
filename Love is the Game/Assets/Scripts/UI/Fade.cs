using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Fade : MonoBehaviour
    {
        public float FadeSpeed;
        public SpriteRenderer SpriteRenderer;

        private float _alpha = 2f;

        // Use this for initialization
        void Start () {
	
        }
	
        // Update is called once per frame
        void Update ()
        {
            _alpha -= FadeSpeed*Time.deltaTime;
            if (_alpha <= 1f)
            {
                var color = SpriteRenderer.material.color;
                color.a = _alpha;
                SpriteRenderer.material.color = color;
            }
        }
    }
}
