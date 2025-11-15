using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Core.Scripts {
    public class card : MonoBehaviour
    {
        protected float health;
        protected float energy;
        protected Collider2D cardCollider;
        protected Camera mainCam;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public virtual void Start()
        {
            cardCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        public void Update()
        {
            
        }
    }
}
