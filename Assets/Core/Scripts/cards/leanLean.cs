using Assets.Core.Scripts;
using UnityEngine;

public class leanLean : card
{
    private float healFactor = 10f;
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
        player currPlayer = FindAnyObjectByType<player>();
        currPlayer.currHealth += healFactor;
    }
}
