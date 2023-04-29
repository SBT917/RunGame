using UnityEngine;
using System;

public class Notes : Character, IMoveable
{
    [SerializeField] protected NotesStatus notesStatus;

    public static float notesSpeedRadix = 100; //ノーツの速度の基準値
    public float speed; //ノーツの速度
    Vector3 direction; //移動する方向
    protected int defaultScore; //ノーツのスコア
    public static event Action<int> onNotesBreak; //ノーツが壊れた時に呼び出されるイベント

    protected override void Awake()
    {
        base.Awake();
        direction = new Vector3(0, 0, -1);
        defaultScore = notesStatus.score;
    }

    void Update()
    {
        Move(direction);
    }

    //カメラ外に出たら消滅させる
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //移動処理(進行方向*基数*速度*デルタタイム)
    public void Move(Vector3 direction)
    {
        transform.position += direction * notesSpeedRadix * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public override void TakeDamage(float damage)
    {
        if (notesStatus.isUnbreakable) return;
        base.TakeDamage(damage);
    }

    public override void Death()
    {
        base.Death();
        onNotesBreak?.Invoke(defaultScore);
    }

}
