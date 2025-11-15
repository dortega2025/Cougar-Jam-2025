using Assets.Core.Scripts;
using UnityEngine;

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
        base.Update();
        if (selected && target != null && !hasAttacked)
        {
            Ability();
            hasAttacked = true;
        }
    }

    void Ability()
    {
        player currPlayer = FindAnyObjectByType<player>();
        currPlayer.currEnergy += extraEnergy;
    }
}
