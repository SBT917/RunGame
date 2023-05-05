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
        //ノーツの間隔(初期値はオフセットを設定し、speedの値によって到達する時間に偏りが出ないようにする)
        float spacing = (CommonGameParam.PLAYER_POSITION_Z + ((-CommonGameParam.PLAYER_POSITION_Z + offset) * musicData.speed));

        for (int i = 0; i < notesDatas.Length; ++i) {
            NotesData notesData = notesDatas[i];
            if (notesData.beat == 0) notesData.beat = notesDatas[i - 1].beat; //beatが0の場合は前のノーツのbeatを引き継ぐ

            var nc = Instantiate(notesContainer, new Vector3(0, 0, spacing), Quaternion.identity, transform); //ノーツの格納場所を生成
            for (int j = 0; j < notesData.place.Length; ++j) {
                if (notesData.place[j] == 0) continue; //placeが0の場合はノーツを生成しない(空白)
                Notes n = Instantiate(noteses[notesData.place[j] - 1], nc.transform);
                n.Init(j, musicData, notesData, spacing);
            }

            //次のノーツまでの間隔を計算
            spacing = nc.transform.position.z + ((60 / musicData.bpm) / (notesData.beat / 4)) * notesSpeed;
        }
    }
}
