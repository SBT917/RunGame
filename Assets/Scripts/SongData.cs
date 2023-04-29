using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongData
{
    public string name; //曲名
    public float bpm; //BPM
    public float offset; //オフセット
    public float speed; //ノーツの速度
    public NotesData[] notesData;

}

[System.Serializable]
public class NotesData
{
    public float beat; //次のノーツが到達するまでの拍数
    public int[] place; //ノーツの配置
}