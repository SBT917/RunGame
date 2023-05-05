using System;
using UnityEngine;

public class Player : Character
{
    public static event Action<float> onPlayerTakeDamage; //プレイヤーがダメージを受けた時に呼び出されるイベント
    public static event Action onPlayerDeath; //プレイヤーが死んだ時に呼び出されるイベント

    public override void Death()
    {
        base.Death();
        onPlayerDeath?.Invoke();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        onPlayerTakeDamage?.Invoke(health);
    }
}
