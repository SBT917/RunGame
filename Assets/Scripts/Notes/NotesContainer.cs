using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesContainer : MonoBehaviour
{
    Notes[] noteses = new Notes[9]; //格納されているノーツ
    Vector3 basisPosition = new Vector3(-3f, 7.5f, 0); //ノーツの座標の基準点
    const float GRID_SIZE = CommonGameParam.GRID_SIZE; //マスの大きさ

    //ノーツを格納し、マスに合わせて座標を設定する
    public void SetNotes(int index, Notes notes)
    {
        noteses[index] = notes;
        if (noteses[index] == null) return;

        if (noteses[index].TryGetComponent(out LineRenderer line)) {
            line.SetPosition(0, basisPosition + new Vector3((index % 3) * GRID_SIZE, (index / 3) * -GRID_SIZE, 0));
            return;
        }

        noteses[index].transform.position = basisPosition + new Vector3((index % 3) * GRID_SIZE, (index / 3) * -GRID_SIZE, transform.position.z);
    }

}
