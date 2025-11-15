using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 10f;
    public GameObject player;
    public bool isTurn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        health -= collision.gameObject.GetComponent<bullet>().damage;
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
