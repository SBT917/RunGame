using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField] Notes[] noteses; //生成するノーツ
    [SerializeField] NotesContainer notesContainer; //ノーツの格納場所
    MusicData musicData; //曲の情報
    float offset;//オフセット
    float notesSpeed;//ノーツの速度

    void Awake()
    {
        musicData = MusicDataReader.GetMusicData();
        offset = CommonGameParam.BASIS_OFFSET + musicData.offset;
        notesSpeed = CommonGameParam.BASIS_NOTES_SPEED * musicData.speed;
        Generate(musicData.notesData);
    }

    //ノーツの生成
    void Generate(NotesData[] notesDatas)
    {
        float spacing = (-100 + ((100 + offset) * musicData.speed)); //ノーツの間隔(初期値はオフセットを設定し、speedの値によって到達する時間に偏りが出ないようにする)

        for (int i = 0; i < notesDatas.Length; ++i) {
            NotesData nd = notesDatas[i];
            if (nd.beat == 0) nd.beat = notesDatas[i - 1].beat; //beatが0の場合は前のノーツのbeatを引き継ぐ

            var nc = Instantiate(notesContainer, new Vector3(0, 0, spacing), Quaternion.identity, transform); //ノーツの格納場所を生成
            for (int j = 0; j < nd.place.Length; ++j) {
                if (nd.place[j] == 0) continue; //placeが0の場合はノーツを生成しない(空白)
                Notes n = Instantiate(noteses[nd.place[j] - 1], nc.transform);
                nc.SetNotes(j, n);
                n.speed = musicData.speed;

                //ラインノーツの場合は終点を設定
                if (n.TryGetComponent(out LineNotes line)) {
                    Vector3 basisPosition = new Vector3(-3f, 7.5f, 0);
                    float end = ((60 / musicData.bpm) / (nd.beat / 4)) * notesSpeed;
                    Vector3 endPoint = basisPosition + new Vector3((nd.lineEnd % 3) * CommonGameParam.GRID_SIZE, (nd.lineEnd / 3) * -CommonGameParam.GRID_SIZE, end);
                    line.SetEndPoint(endPoint);
                }
            }

            //次のノーツまでの間隔を計算
            spacing = nc.transform.position.z + ((60 / musicData.bpm) / (nd.beat / 4)) * notesSpeed;
        }
    }
}
