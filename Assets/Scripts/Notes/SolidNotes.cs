using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidNotes : Notes
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IAttackable attack;
            if (other.TryGetComponent(out attack))
            {

            }
        }

    }
}
