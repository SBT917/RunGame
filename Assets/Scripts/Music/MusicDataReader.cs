using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDataReader : MonoBehaviour
{
    [SerializeField] TextAsset jsonFile; //曲の情報が書かれたjsonファイル
    static public MusicData musicData; //jsonファイルから読み込んだ曲の情報

    void Awake()
    {
        ReadJson();
    }

    //JSONファイルを読み込む
    void ReadJson()
    {
        string jsonText = jsonFile.text;
        musicData = JsonUtility.FromJson<MusicData>(jsonText);
    }

    //曲の情報を返す
    static public MusicData GetMusicData()
    {
        return musicData;
    }


}
