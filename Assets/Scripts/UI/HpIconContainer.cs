using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpIconContainer : MonoBehaviour
{
    [SerializeField] GameObject hpIcon; //HPアイコン
    [SerializeField] DefaultStatus playerDefaultStatus; //プレイヤーのデフォルトステータス
    void Start()
    {
        Player.onPlayerTakeDamage += UpdateHpIcon;
        UpdateHpIcon(playerDefaultStatus.health);
    }

    //HPアイコンの更新
    void UpdateHpIcon(float hp)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < hp; ++i)
        {
            Instantiate(hpIcon, transform);
        }
    }
}
