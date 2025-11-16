using Assets.Core.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class bankBank : card
{
    private float extraEnergy = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        energy = 1f;
    }

    // Update is called once per frame
    void Update()
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
        if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.CompareTag("player"))
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
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.GetComponent<player>().currEnergy +=extraEnergy;
    }
}
