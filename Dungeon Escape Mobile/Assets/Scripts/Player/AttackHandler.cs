using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<IDamageable>(out IDamageable hit);

        hit.HandleDamage(5);
    }
}
