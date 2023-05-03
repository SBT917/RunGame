using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicPlayer : MonoBehaviour
{
    MusicData musicData; //曲の情報
    AudioSource audioSource; //オーディオソース

    void Start()
    {
        musicData = MusicDataReader.GetMusicData();
        TryGetComponent(out audioSource);
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        float waitTime = (CommonGameParam.BASIS_OFFSET + musicData.offset) * (60 / musicData.bpm);
        yield return new WaitForSeconds(0.95f);
        audioSource.Play();
    }
}
