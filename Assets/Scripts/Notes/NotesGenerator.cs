using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField] Notes[] noteses; //生成するノーツ配列
    [SerializeField] TextAsset jsonFile; //曲の情報が書かれたjsonファイル
    SongData songData; //jsonファイルから読み込んだ曲の情報

    void Start()
    {
        string jsonText = jsonFile.text;
        songData = JsonUtility.FromJson<SongData>(jsonText);
    }

    void Update()
    {
        foreach (NotesData n in songData.notesData)
        {

        }
    }
}
