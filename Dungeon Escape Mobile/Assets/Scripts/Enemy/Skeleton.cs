using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set;}


    public override void Init() //Serve para inicializar variáveis no lugar de start
    {
        base.Init();
        Health = base.health;
    }

    public void HandleDamage(int damageAmount)
    {
        health = (Mathf.Max(base.health - damageAmount, 0));

        if(health == 0)
            Debug.Log("E morreu");
    }
}
