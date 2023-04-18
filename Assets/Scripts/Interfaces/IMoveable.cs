using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    /**  
    <summary>
    移動処理
    </summary>
    */
    void Move(Vector3 direction);

    /**  
    <summary>
    移動する方向を設定する
    </summary>
    */
    void SetDirection(Vector3 direction);

    /**  
    <summary>
    移動している方向を取得する
    </summary>
    */
    Vector3 GetDirection();
}
