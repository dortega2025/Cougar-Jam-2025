using UnityEngine;

public class skellington : enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        health = 10f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        base.Update();
    }
}
