using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable, IDashable
{
    [SerializeField] float moveSpeed; //プレイヤーの移動速度
    [SerializeField] float dashSpeed; //プレイヤーのダッシュ速度
    [SerializeField] Vector2 rangeMovableMin; //移動可能範囲の最小値
    [SerializeField] Vector2 rangeMovableMax; //移動可能範囲の最大値

    Vector3 direction; //移動方向
    Rigidbody rb; //Rigidbody


    void Awake()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        Move(direction);
        ClampPosition();

    }

    //移動処理
    public void Move(Vector3 direction)
    {
        rb.AddForce(direction * moveSpeed);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    //ダッシュ処理
    public void Dash(Vector3 direction)
    {
        rb.AddForce(direction * dashSpeed, ForceMode.Impulse);
    }

    //移動範囲の制限
    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, rangeMovableMin.x, rangeMovableMax.x);
        pos.y = Mathf.Clamp(pos.y, rangeMovableMin.y, rangeMovableMax.y);
        transform.position = pos;
    }
}
