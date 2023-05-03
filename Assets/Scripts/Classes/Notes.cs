using UnityEngine;
using System;

public class Notes : Character, IMoveable
{
    [SerializeField] protected NotesStatus notesStatus;

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

    void FixedUpdate()
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
        transform.position += direction * CommonGameParam.NOTES_BASIS_SPEED * speed * Time.deltaTime;
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
        Debug.Log(Time.time + "秒でノーツが壊れました。");
        onNotesBreak?.Invoke(defaultScore);
    }

}
