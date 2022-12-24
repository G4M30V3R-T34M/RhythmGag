using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] ActSongs actSongs;
    [SerializeField] FloatVariable currentAct;
    [SerializeField] FloatReference startWaitTime;
    [SerializeField] FloatReference fadeSpeed;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameEvent startAct;

    void Start() {
        currentAct.SetValue(0);
        StartCoroutine(FadeInSong(actSongs.songs[(int)currentAct.Value]));
    }

    public void FadeOutSong() {
        StartCoroutine(DoFadeOutSong());
    }

    private IEnumerator DoFadeOutSong() {
        yield return null;
        audioSource.volume = 1;
        while (audioSource.volume > 0) {
            yield return null;
            audioSource.volume -= fadeSpeed * Time.deltaTime;
        }
        audioSource.Stop();
    }

    public void LoadNewAct() {
        currentAct.SetValue(currentAct.Value + 1);
        StartCoroutine(FadeInSong(actSongs.songs[(int)currentAct.Value]));
    }

    private IEnumerator FadeInSong(Song_SO songData) {
        audioSource.volume = 0;
        audioSource.clip = songData.song;
        audioSource.Play();
        while (audioSource.volume < 1) {
            yield return null;
            audioSource.volume += fadeSpeed * Time.deltaTime;
        }
        audioSource.volume = 1;
        startAct.Raise();
    }
}
