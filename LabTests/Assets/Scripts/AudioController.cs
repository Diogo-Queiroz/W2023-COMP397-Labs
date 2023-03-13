using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSettings audioSettingsSFX;
    public AudioSettings audioSettingsAmbience;

    public AudioSource audioSourceSFX;
    public AudioSource audioSourceAmbience;

    public static AudioController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        audioSourceSFX.volume = audioSettingsSFX.volume;
        audioSourceAmbience.volume = audioSettingsAmbience.volume;
        PlayAmbienceAudio("music-electronic-115-bpm");
    }

    public void PlayAmbienceAudio(string clipName)
    {
        AudioClip clip = audioSettingsAmbience.GetAudioClip(clipName);
        if (clip != null)
        {
            audioSourceAmbience.clip = clip;
            audioSourceAmbience.loop = true;
            audioSourceAmbience.Play();
        }
    }

    public void StopAmbienceAudio()
    {
        audioSourceAmbience.Stop();
    }

    public void PlaySFXAudio(string clipName)
    {
        AudioClip clip = audioSettingsSFX.GetAudioClip(clipName);
        if (clip != null)
        {
            audioSourceSFX.PlayOneShot(clip);
        }
    }
}
