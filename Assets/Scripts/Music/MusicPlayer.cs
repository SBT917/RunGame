using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        TryGetComponent(out audioSource);
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(CommonGameParam.PLAY_MUSIC_DELAY);
        audioSource.Play();
    }
}
