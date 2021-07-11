using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public interface IDamageable
    {
        int Health { get; set; }

        void HandleDamage(int damageAmount);
    }
}
