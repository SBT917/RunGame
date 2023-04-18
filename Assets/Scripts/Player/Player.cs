using System;
using UnityEngine;

public class Player : Character
{
    public static event Action onPlayerDeath; //プレイヤーが死んだ時に呼び出されるイベント

    public override void Death()
    {
        base.Death();
        onPlayerDeath?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        if (other.TryGetComponent(out damageable))
        {
            damageable.TakeDamage(1);
        }

    }
}
