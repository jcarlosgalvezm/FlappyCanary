using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    public static SoundSystem instance;
    public AudioClip audioCoin;
    public AudioClip audioFlap;
    public AudioClip audioHit;
    public AudioSource audioSourceFXMove;
    public AudioSource audioSourceFXScore;
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceEnding;


    private void Awake()
    {
        if (SoundSystem.instance == null)
            SoundSystem.instance = this;

        else if (SoundSystem.instance != this)
            Destroy(gameObject);
    }

    public void PlayEnding()
    {
        audioSourceEnding.Play();
    }

    public void PlaySounds() {
        audioSourceMusic.mute = false;
        audioSourceFXMove.mute = false;
    }

    public void StopSounds()
    {
        audioSourceMusic.mute = true;
        audioSourceFXMove.mute = true;
    }

    public void PlayCoin()
    {
        audioSourceFXScore.clip = audioCoin;
        audioSourceFXScore.Play();
    }

    public void PlayFlap()
    {
        PlayAudioClip(audioFlap);
    }

    public void PlayHit()
    {
        PlayAudioClip(audioHit);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSourceFXMove.clip = audioClip;
        audioSourceFXMove.Play();
    }

    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
            SoundSystem.instance = null;
    }
}
