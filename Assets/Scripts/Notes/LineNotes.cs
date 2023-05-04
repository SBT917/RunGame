using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNotes : Notes
{
    LineRenderer line;

    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out line);
    }

    public void SetEndPoint(Vector3 endPoint)
    {
        line.SetPosition(1, endPoint);
    }
}
