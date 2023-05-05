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

    public override void Init(int glidIndex, MusicData md, NotesData nd, float spacing)
    {
        this.speed = md.speed;
        this.beat = nd.beat;

        Vector3 basisPosition = CommonGameParam.BASIS_NOTES_POSITION;
        float gridSize = CommonGameParam.GRID_SIZE;
        float endPoint = transform.position.z + ((60 / md.bpm) / (nd.beat / 4)) * (CommonGameParam.BASIS_NOTES_SPEED * this.speed) * nd.lineLength;

        transform.position = new Vector3(0, 0, spacing);
        line.SetPosition(0, basisPosition + new Vector3((glidIndex % 3) * gridSize, (glidIndex / 3) * -gridSize, 0));
        line.SetPosition(1, basisPosition + new Vector3((nd.lineEnd % 3) * gridSize, (nd.lineEnd / 3) * -gridSize, endPoint));

    }

}
