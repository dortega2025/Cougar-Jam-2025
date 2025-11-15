using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Assets.Core.Scripts {
    public class card : MonoBehaviour
    {
        protected float energy;
        public bool selected;
        [SerializeField] protected enemy target;
        [SerializeField] protected card targetCard;
        protected bool hasAttacked;
        public bool playerTurn;
        public bool extraTurn;
        public float damageModifier = 0;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public virtual void Start()
        {
            
        }

        // Update is called once per frame
        public void Update()
        {
            if (playerTurn)
            {
                IsClicked();
            }
            if (selected)
            {
                SelectTarget();
            }
            if (hasAttacked && !extraTurn)
            {
                StartCoroutine(Discard());
            } else if (hasAttacked && extraTurn)
            {
                extraTurn = false;
                hasAttacked = false;
            }
        }

        void IsClicked()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector2.zero, 0);
            if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.gameObject == gameObject)
            {
                if (!selected)
                {
                    selected = true;
                } else
                {
                    selected = false;
                }
            }
        }

        void SelectTarget()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector2.zero, 0);
            if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.CompareTag("enemy"))
            {
                target = hitData.collider.gameObject.GetComponent<enemy>();
            }
        }

        public IEnumerator Discard()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
