using System;
using Assets.Core.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class batBat : card
{
    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        health = 10f;
        energy = 2f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        base.Update();
        isClicked();
    }

    void isClicked()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector2.zero, 0);
        if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.CompareTag("batBat"))
        {
            batBatAbility();
        }
    }

    void batBatAbility()
    {
        Debug.Log("Clicked");
    }
}


