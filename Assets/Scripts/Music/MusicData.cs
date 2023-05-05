[System.Serializable]
public class MusicData
{
    public string name; //曲名
    public float bpm; //BPM
    public float offset; //オフセット
    public float speed; //ノーツの速度
    public string source; //曲のファイル名
    public NotesData[] notesData;

}

[System.Serializable]
public class NotesData
{
    public float beat; //次のノーツが到達するまでの拍数
    public int[] place; //ノーツの配置
    public int lineLength; //ラインノーツの長さ
    public int lineEnd; //ラインノーツの終点

}