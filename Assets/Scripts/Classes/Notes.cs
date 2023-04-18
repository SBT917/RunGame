using UnityEngine;
using System;

public class Notes : Character, IMoveable
{
    [SerializeField] protected NotesStatus notesStatus;

    Vector3 direction; //移動する方向
    public static event Action<int> onNotesBreak; //ノーツが壊れた時に呼び出されるイベント

    protected override void Awake()
    {
        base.Awake();
        direction = new Vector3(0, 0, -1);
    }

    void Update()
    {
        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * 10 * Time.deltaTime;
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
        onNotesBreak?.Invoke(notesStatus.score);
    }

}
