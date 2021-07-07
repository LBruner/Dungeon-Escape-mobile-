using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] GameObject acidPrefab = null;
    [SerializeField] Transform fireSpawn = null;
    
    public override void Init() //Serve para inicializar variáveis no lugar de start
    {
        base.Init();
        Health = base.health;
        SpiderAnimationEvent.OnFireAnimationEvent += Attack;
    }

    public override void Update()
    {
        
    }

    private void Attack()
    {
        GameObject acidInstance = Instantiate(acidPrefab, fireSpawn.position, Quaternion.identity);
    }

}
