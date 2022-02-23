using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSong : MonoBehaviour
{
    public AudioSource[] randomAudio;

    public void Start()
    {
        AudioSource a = randomAudio[Random.Range(0, randomAudio.Length)];
        a.volume = 0.5f;

        StartCoroutine(waitToStart(a));
    }

    IEnumerator waitToStart(AudioSource a)
    {
        yield return new WaitForSeconds(3f);
        a.Play();
    }
}
