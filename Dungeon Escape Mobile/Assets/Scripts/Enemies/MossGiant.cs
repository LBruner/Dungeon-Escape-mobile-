using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : EnemyAIController
{
    public override void Init() //Serve para inicializar variáveis no lugar de start
    {
        base.Init();
        Health = base.health;
    } 
}
