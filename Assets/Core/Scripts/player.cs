using Assets.Core.Scripts;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool playerTurn;
    private float maxHealth = 50f;
    public float currHealth = 50f;
    private float maxEnergy = 10f;
    public float currEnergy = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
