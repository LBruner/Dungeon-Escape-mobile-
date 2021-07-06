﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init() //Serve para inicializar variáveis no lugar de start!
    {
        base.Init();
        Health = base.health;
    }

    public void HandleDamage(int damageAmount)
    {
        
    }

}
