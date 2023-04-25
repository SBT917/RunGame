using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        if (other.TryGetComponent(out damageable))
        {
            damageable.TakeDamage(1);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }
}
