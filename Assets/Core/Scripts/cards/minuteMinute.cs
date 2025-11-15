using Assets.Core.Scripts;
using NUnit.Framework;
using UnityEngine;

public class minuteMinute : card
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        energy = 3f;
    }

    // Update is called once per frame
    public virtual void Update()
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
        battleSystemManager battleSystem = FindAnyObjectByType<battleSystemManager>();
        battleSystem.turnOrder.Dequeue();
        battleSystem.turnOrder.Dequeue();
    }
}
