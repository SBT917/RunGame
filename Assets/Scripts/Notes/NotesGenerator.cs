using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField] Notes[] noteses; //生成するノーツ配列
    MusicData musicData; //曲の情報
    Vector3 basisPosition = new Vector3(-3f, 7.5f, 0); //ノーツの出現場所の基準点

    const float GRID_SIZE = CommonGameParam.GRID_SIZE; //マスの大きさ
    const float BASIS_OFFSET = CommonGameParam.BASIS_OFFSET; //オフセット

    void Start()
    {
        musicData = MusicDataReader.GetMusicData();
        Generate(musicData.notesData);
    }

    //ノーツの生成
    void Generate(NotesData[] notesDatas)
    {
        float offset = BASIS_OFFSET + musicData.offset; //オフセット
        float spacing = (-100 + ((100 + offset) * musicData.speed)); //ノーツの間隔(初期値はオフセットを設定し、speedの値によって到達する時間に偏りが出ないようにする)
        //マジックナンバーの100はプレイヤーのz軸とbasisPositionのz軸の距離を表す

        for (int i = 0; i < notesDatas.Length; ++i) {
            NotesData nd = notesDatas[i];
            if (nd.beat == 0) nd.beat = notesDatas[i - 1].beat; //beatが0の場合は前のノーツのbeatを引き継ぐ

            Notes n = null;
            int index = 0;
            for (int j = 0; j < 3; ++j) {
                for (int k = 0; k < 3; ++k) {
                    if (nd.place[index] != 0) {
                        Vector3 position = basisPosition + new Vector3(k * GRID_SIZE, j * -GRID_SIZE, spacing);
                        n = Instantiate(noteses[nd.place[index] - 1], position, Quaternion.identity, transform);
                        n.speed = musicData.speed;
                    }
                    ++index;
                }
            }
            //次のノーツまでの間隔を計算
            spacing = n.transform.position.z + ((60 / musicData.bpm) / (nd.beat / 4)) * (CommonGameParam.NOTES_BASIS_SPEED * musicData.speed);

        }



    }
}
