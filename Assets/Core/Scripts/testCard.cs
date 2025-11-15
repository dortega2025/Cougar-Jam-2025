using System;
using Assets.Core.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class testCard : card
{
    [SerializeField] GameObject target;
    public GameObject bulletPrefab;
    private float fireSpeed = 10f;
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
        IsClicked();
        SelectTarget();
    }

    void SelectTarget()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector2.zero, 0);
        if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame)
        {
            target = hitData.collider.gameObject;
            Attack();
        }
    }

    void IsClicked()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector2.zero, 0);
        if (hitData.collider && Mouse.current.leftButton.wasPressedThisFrame && hitData.collider.CompareTag("testCard"))
        {
            Ability();
        }
    }

    void Ability()
    {
        Debug.Log("Clicked Test 2");
    }

    void Attack()
    {
        GameObject bullet;
        Vector2 direction = target.transform.position - transform.position;
        // float playerAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = fireSpeed * direction.normalized;
    }
}


