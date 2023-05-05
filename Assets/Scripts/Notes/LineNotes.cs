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
        float endPoint = ((60 / md.bpm) / (nd.beat / 4)) * (CommonGameParam.BASIS_NOTES_SPEED * this.speed) * nd.lineLength;

        //生成されたラインに合わせてコライダーを設定する
        //以下引用:https://zenn.dev/ekito_station/articles/linerenderer-boxcollider
        Vector3 startPos = basisPosition + new Vector3((glidIndex % 3) * gridSize, (glidIndex / 3) * -gridSize, 0); //ラインの始点
        Vector3 endPos = basisPosition + new Vector3((nd.lineEnd % 3) * gridSize, (nd.lineEnd / 3) * -gridSize, endPoint); //ラインの終点
        Vector3 lineVec = endPos - startPos; //ラインのベクトルを取得
        float dist = lineVec.magnitude; //ラインの長さを取得

        //取得した長さ分の直線を書く
        Vector3 lineZ = new Vector3(0, 0, dist);
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, lineZ);

        //コライダーの設定
        var col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;
        col.size = new Vector3(2.0f, 2.0f, col.size.z);

        line.transform.rotation = Quaternion.FromToRotation(lineZ, lineVec); // 本来の方向に回転する
        line.transform.position += startPos; // 本来の位置に移動する


    }

}
