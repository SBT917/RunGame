using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Notes Status", menuName = "Notes Status")]
public class NotesStatus : ScriptableObject
{
    public int score; //ノーツのスコア
    public bool isUnbreakable; //ノーツが破壊不可かどうか
}
