using Assets.Core.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class trainTrain : card
{
    private float damageFactor = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        energy = 3f;
    }

    // Update is called once per frame
    public virtual void Update()
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
        if (selected && target != null && !hasAttacked)
        {
            Ability();
            hasAttacked = true;
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
        if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.CompareTag("card"))
        {
            targetCard = hitData.collider.gameObject.GetComponent<card>();
        }
    }

    void Ability()
    {
        targetCard.damageModifier += damageFactor;
    }
}
