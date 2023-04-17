using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    void Move(Vector3 direction);
    void SetDirection(Vector3 direction);
    Vector3 GetDirection();
}
