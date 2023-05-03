using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNotes : Notes
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            IDamageable damage;
            if (other.TryGetComponent(out damage)) {
                damage.TakeDamage(1);
                Destroy(gameObject);
            }
        }

    }
}
