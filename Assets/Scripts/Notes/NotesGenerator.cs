using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField] Notes[] noteses; //生成するノーツ配列
    [SerializeField] TextAsset jsonFile; //曲の情報が書かれたjsonファイル
    SongData songData; //jsonファイルから読み込んだ曲の情報

    const float GRID_SIZE = 3.0f; //マスの大きさ
    Vector3 basisPoint = new Vector3(-3f, 7.5f, 0); //ノーツの出現場所の基準点
    float basisOffset = 150.0f; //オフセットの基準値

    void Start()
    {
        string jsonText = jsonFile.text;
        songData = JsonUtility.FromJson<SongData>(jsonText);
        Generate(songData.notesData);
    }

    //ノーツの生成
    void Generate(NotesData[] notesDatas)
    {
        float spacing = basisOffset; //ノーツの間隔
        for (int i = 0; i < notesDatas.Length; ++i)
        {
            NotesData nd = notesDatas[i];
            if (nd.beat == 0) nd.beat = notesDatas[i - 1].beat; //beatが0の場合は前のノーツのbeatを引き継ぐ

            Notes n = null; //最後に生成したノーツを入れる
            int index = 0;
            for (int j = 0; j < 3; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    if (nd.place[index] != 0)
                    {
                        Vector3 position = basisPoint + new Vector3(k * GRID_SIZE, j * -GRID_SIZE, spacing);
                        n = Instantiate(noteses[nd.place[index] - 1], position, Quaternion.identity, transform);
                        n.speed = songData.speed;

                    }
                    ++index;
                }
            }
            //次のノーツまでの間隔を計算
            spacing = n.transform.position.z + ((60 / songData.bpm) / (nd.beat / 4)) * (Notes.notesSpeedRadix * songData.speed);

        }



    }
}
