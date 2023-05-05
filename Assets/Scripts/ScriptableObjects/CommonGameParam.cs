using UnityEngine;

public class CommonGameParam
{
    public const float BASIS_NOTES_SPEED = 100.0f; //全ての曲で共通なノーツの基準速度
    public const float BASIS_OFFSET = 120.0f; //全ての曲で共通なオフセットの基準
    public static readonly Vector3 BASIS_NOTES_POSITION = new Vector3(-3f, 7.5f, 0); //ノーツの座標の基準点
    public const float PLAYER_POSITION_Z = -100; //プレイヤーのZ座標
    public const float PLAY_MUSIC_DELAY = 2.0f; //曲の再生までの待機時間
    public const float GRID_SIZE = 3.0f; //マスの大きさ

}

