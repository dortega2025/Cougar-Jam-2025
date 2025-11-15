using Assets.Core.Scripts;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class pensPen : card
{
    public GameObject shieldPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        base.Start();
        energy = 2f;
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
        Instantiate(shieldPrefab, target.transform.position - new Vector3(0, 5, 0), Quaternion.identity);
    }
}
