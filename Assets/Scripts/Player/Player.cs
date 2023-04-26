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
}
