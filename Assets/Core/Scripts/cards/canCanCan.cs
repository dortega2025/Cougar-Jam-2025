using Assets.Core.Scripts;
using UnityEngine;

public class canCanCan : card
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        energy = 5f;
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        int rand = Random.Range(0, enemies.Length - 1);
        target.player = enemies[rand];
        currPlayer.currEnergy -= energy;
    }
}
