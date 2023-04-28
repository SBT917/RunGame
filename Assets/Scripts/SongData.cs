using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongData
{
    public string name;
    public float bpm;
    public float offset;
    public NotesData[] notesData;

}

[System.Serializable]
public class NotesData
{
    public float beat;
    public int[] place;
}