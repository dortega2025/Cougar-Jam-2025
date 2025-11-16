using System;
using System.Collections.Generic;
using Assets.Core.Scripts;
using UnityEngine;

public class battleSystemManager : MonoBehaviour
{
    public Queue<GameObject> turnOrder = new Queue<GameObject>();
    public GameObject player;
    public GameObject[] enemies;
    public bool win;
    public bool lose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        turnOrder.Enqueue(player);
        for (int i = 0; i < enemies.Length; i++)
        {
            turnOrder.Enqueue(enemies[i]);
        }
        ActivateCards();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOrder.Count <= 1)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            turnOrder.Enqueue(player);
            for (int i = 0; i < enemies.Length; i++)
            {
                turnOrder.Enqueue(enemies[i]);
            }
        }
    }

    public void nextTurn()
    {
        Debug.Log(turnOrder.Peek().ToString());
        turnOrder.Dequeue();
        if (turnOrder.Peek() == player)
        {
            ActivateCards();
        } else
        {
            DeactivateCards();
        }
        if (turnOrder.Peek().CompareTag("enemy"))
        {
            turnOrder.Peek().GetComponent<enemy>().isTurn = true;
        }
    }

    void ActivateCards()
    {
        card[] cards = FindObjectsByType<card>(FindObjectsSortMode.None);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].playerTurn = true;
        }
    }

    void DeactivateCards()
    {
        card[] cards = FindObjectsByType<card>(FindObjectsSortMode.None);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].playerTurn = false;
        }
    }
}
